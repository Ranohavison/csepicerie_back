using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class RapportEndpoints
{
    public static void MapRapportEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Rapport");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Rapports.ToListAsync();
        })
        .WithName("GetAllRapports");

        group.MapGet("/{id}", async Task<Results<Ok<Rapport>, NotFound>> (int idrapport,[FromServices] CsepicerieDbContext db) =>
        {
            return await db.Rapports.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdRapport == idrapport)
                is Rapport model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetRapportById");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idrapport, [FromBody] Rapport rapport, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Rapports
                .Where(model => model.IdRapport == idrapport)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdRapport, rapport.IdRapport)
                    .SetProperty(m => m.Type, rapport.Type)
                    .SetProperty(m => m.Periode, rapport.Periode)
                    .SetProperty(m => m.DateGeneration, rapport.DateGeneration)
                    .SetProperty(m => m.FichierPdf, rapport.FichierPdf)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateRapport");

        group.MapPost("/", async ([FromBody] Rapport rapport, [FromServices] CsepicerieDbContext db) =>
        {
            db.Rapports.Add(rapport);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Rapport/{rapport.IdRapport}",rapport);
        })
        .WithName("CreateRapport");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idrapport,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Rapports
                .Where(model => model.IdRapport == idrapport)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteRapport");
    }
}
