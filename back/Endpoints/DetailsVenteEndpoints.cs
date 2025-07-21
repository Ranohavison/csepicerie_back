using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class DetailsVenteEndpoints
{
    public static void MapDetailsVenteEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/DetailsVente");

        group.MapGet("/", async ( [FromServices] CsepicerieDbContext db) =>
        {
            return await db.DetailsVentes.ToListAsync();
        })
        .WithName("GetAllDetailsVentes")
        .WithGroupName("transactions");

        group.MapGet("/{id}", async Task<Results<Ok<DetailsVente>, NotFound>> (int id, [FromServices]  CsepicerieDbContext db) =>
        {
            return await db.DetailsVentes.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is DetailsVente model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDetailsVenteById")
        .WithGroupName("transactions");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromBody] DetailsVente detailsVente, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.DetailsVentes
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, detailsVente.Id)
                    .SetProperty(m => m.IdVente, detailsVente.IdVente)
                    .SetProperty(m => m.IdProduit, detailsVente.IdProduit)
                    .SetProperty(m => m.Quantite, detailsVente.Quantite)
                    .SetProperty(m => m.PrixUnitaire, detailsVente.PrixUnitaire)
                    .SetProperty(m => m.Remise, detailsVente.Remise)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDetailsVente")
        .WithGroupName("transactions");

        group.MapPost("/", async ( [FromBody] DetailsVente detailsVente, [FromServices] CsepicerieDbContext db) =>
        {
            db.DetailsVentes.Add(detailsVente);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/DetailsVente/{detailsVente.Id}",detailsVente);
        })
        .WithName("CreateDetailsVente")
        .WithGroupName("transactions");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.DetailsVentes
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDetailsVente")
        .WithGroupName("transactions");
    }
}
