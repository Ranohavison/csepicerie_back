using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class FournisseurEndpoints
{
    public static void MapFournisseurEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Fournisseur");

        group.MapGet("/", async (CsepicerieDbContext db) =>
        {
            return await db.Fournisseurs.ToListAsync();
        })
        .WithName("GetAllFournisseurs")
        .WithGroupName("transactions");

        group.MapGet("/{idfournisseur}", async Task<Results<Ok<Fournisseur>, NotFound>> (int idfournisseur,[FromServices] CsepicerieDbContext db) =>
        {
            return await db.Fournisseurs.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdFournisseur == idfournisseur)
                is Fournisseur model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetFournisseurById")
        .WithGroupName("transactions");

        group.MapPut("/{idfournisseur}", async Task<Results<Ok, NotFound>> (int idfournisseur, [FromBody] Fournisseur fournisseur,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Fournisseurs
                .Where(model => model.IdFournisseur == idfournisseur)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdFournisseur, fournisseur.IdFournisseur)
                    .SetProperty(m => m.Nom, fournisseur.Nom)
                    .SetProperty(m => m.Adresse, fournisseur.Adresse)
                    .SetProperty(m => m.Telephone, fournisseur.Telephone)
                    .SetProperty(m => m.Email, fournisseur.Email)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateFournisseur")
        .WithGroupName("transactions");

        group.MapPost("/", async ( [FromBody] Fournisseur fournisseur,[FromServices] CsepicerieDbContext db) =>
        {
            db.Fournisseurs.Add(fournisseur);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Fournisseur/{fournisseur.IdFournisseur}",fournisseur);
        })
        .WithName("CreateFournisseur")
        .WithGroupName("transactions");

        group.MapDelete("/{idfournisseur}", async Task<Results<Ok, NotFound>> (int idfournisseur,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Fournisseurs
                .Where(model => model.IdFournisseur == idfournisseur)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteFournisseur")
        .WithGroupName("transactions");
    }
}
