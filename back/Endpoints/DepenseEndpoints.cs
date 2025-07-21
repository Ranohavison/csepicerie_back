using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class DepenseEndpoints
{
    public static void MapDepenseEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Depense");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Depenses.ToListAsync();
        })
        .WithName("GetAllDepenses")
        .WithGroupName("transactions");

        group.MapGet("/{iddepense}", async Task<Results<Ok<Depense>, NotFound>> (int iddepense,[FromServices] CsepicerieDbContext db) =>
        {
            return await db.Depenses.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdDepense == iddepense)
                is Depense model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDepenseById")
        .WithGroupName("transactions");

        group.MapPut("/{iddepense}", async Task<Results<Ok, NotFound>> (int iddepense, [FromBody] Depense depense,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Depenses
                .Where(model => model.IdDepense == iddepense)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdDepense, depense.IdDepense)
                    .SetProperty(m => m.Libelle, depense.Libelle)
                    .SetProperty(m => m.Montant, depense.Montant)
                    .SetProperty(m => m.DateDepense, depense.DateDepense)
                    .SetProperty(m => m.Categorie, depense.Categorie)
                    .SetProperty(m => m.Justificatif, depense.Justificatif)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDepense")
        .WithGroupName("transactions");

        group.MapPost("/", async ( [FromBody] Depense depense,[FromServices] CsepicerieDbContext db) =>
        {
            db.Depenses.Add(depense);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Depense/{depense.IdDepense}",depense);
        })
        .WithName("CreateDepense")
        .WithGroupName("transactions");

        group.MapDelete("/{iddepense}", async Task<Results<Ok, NotFound>> (int iddepense,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Depenses
                .Where(model => model.IdDepense == iddepense)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDepense")
        .WithGroupName("transactions");
    }
}
