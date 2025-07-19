using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class SauvegardeEndpoints
{
    public static void MapSauvegardeEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Sauvegarde");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Sauvegardes.ToListAsync();
        })
        .WithName("GetAllSauvegardes");

        group.MapGet("/{id}", async Task<Results<Ok<Sauvegarde>, NotFound>> (int idsauvegarde, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.Sauvegardes.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdSauvegarde == idsauvegarde)
                is Sauvegarde model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSauvegardeById");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idsauvegarde, [FromBody] Sauvegarde sauvegarde, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Sauvegardes
                .Where(model => model.IdSauvegarde == idsauvegarde)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdSauvegarde, sauvegarde.IdSauvegarde)
                    .SetProperty(m => m.Type, sauvegarde.Type)
                    .SetProperty(m => m.CheminFichier, sauvegarde.CheminFichier)
                    .SetProperty(m => m.DateSauvegarde, sauvegarde.DateSauvegarde)
                    .SetProperty(m => m.Declencheur, sauvegarde.Declencheur)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSauvegarde");

        group.MapPost("/", async ([FromBody] Sauvegarde sauvegarde, [FromServices] CsepicerieDbContext db) =>
        {
            db.Sauvegardes.Add(sauvegarde);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Sauvegarde/{sauvegarde.IdSauvegarde}",sauvegarde);
        })
        .WithName("CreateSauvegarde");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idsauvegarde, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Sauvegardes
                .Where(model => model.IdSauvegarde == idsauvegarde)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSauvegarde");
    }
}
