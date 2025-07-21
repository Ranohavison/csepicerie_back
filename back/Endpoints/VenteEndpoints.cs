using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class VenteEndpoints
{
    public static void MapVenteEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Vente");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Ventes.ToListAsync();
        })
        .WithName("GetAllVentes")
        .WithGroupName("transactions");

        group.MapGet("/{idvente}", async Task<Results<Ok<Vente>, NotFound>> (int idvente, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.Ventes.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdVente == idvente)
                is Vente model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetVenteById")
        .WithGroupName("transactions");

        group.MapPut("/{idvente}", async Task<Results<Ok, NotFound>> (int idvente, [FromBody] Vente vente, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Ventes
                .Where(model => model.IdVente == idvente)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdVente, vente.IdVente)
                    .SetProperty(m => m.IdClient, vente.IdClient)
                    .SetProperty(m => m.IdUtilisateur, vente.IdUtilisateur)
                    .SetProperty(m => m.DateVente, vente.DateVente)
                    .SetProperty(m => m.Total, vente.Total)
                    .SetProperty(m => m.Paiement, vente.Paiement)
                    .SetProperty(m => m.Status, vente.Status)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateVente")
        .WithGroupName("transactions");

        group.MapPost("/", async ([FromBody] Vente vente, [FromServices] CsepicerieDbContext db) =>
        {
            db.Ventes.Add(vente);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Vente/{vente.IdVente}",vente);
        })
        .WithName("CreateVente")
        .WithGroupName("transactions");

        group.MapDelete("/{idvente}", async Task<Results<Ok, NotFound>> (int idvente, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Ventes
                .Where(model => model.IdVente == idvente)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteVente")
        .WithGroupName("transactions");
    }
}
