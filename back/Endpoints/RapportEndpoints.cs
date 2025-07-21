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
        .WithName("GetAllRapports")
        .WithGroupName("rapports");

        group.MapGet("/{idrapport}", async Task<Results<Ok<Rapport>, NotFound>> (int idrapport,[FromServices] CsepicerieDbContext db) =>
        {
            return await db.Rapports.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdRapport == idrapport)
                is Rapport model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetRapportById")
        .WithGroupName("rapports");

        group.MapPut("/{idrapport}", async Task<Results<Ok, NotFound>> (int idrapport, [FromBody] Rapport rapport, [FromServices] CsepicerieDbContext db) =>
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
        .WithName("UpdateRapport")
        .WithGroupName("rapports");

        group.MapPost("/", async ([FromBody] Rapport rapport, [FromServices] CsepicerieDbContext db) =>
        {
            db.Rapports.Add(rapport);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Rapport/{rapport.IdRapport}",rapport);
        })
        .WithName("CreateRapport")
        .WithGroupName("rapports");

        group.MapDelete("/{idrapport}", async Task<Results<Ok, NotFound>> (int idrapport,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Rapports
                .Where(model => model.IdRapport == idrapport)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteRapport")
        .WithGroupName("rapports");
    }
}
