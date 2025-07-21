using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class PointageEndpoints
{
    public static void MapPointageEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Pointage");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Pointages.ToListAsync();
        })
        .WithName("GetAllPointages")
        .WithGroupName("rapports");

        group.MapGet("/{idpointage}", async Task<Results<Ok<Pointage>, NotFound>> (int idpointage, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.Pointages.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdPointage == idpointage)
                is Pointage model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPointageById")
        .WithGroupName("rapports");

        group.MapPut("/{idpointage}", async Task<Results<Ok, NotFound>> (int idpointage, [FromBody] Pointage pointage, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Pointages
                .Where(model => model.IdPointage == idpointage)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdPointage, pointage.IdPointage)
                    .SetProperty(m => m.IdUtilisateur, pointage.IdUtilisateur)
                    .SetProperty(m => m.Date, pointage.Date)
                    .SetProperty(m => m.HeureArrivee, pointage.HeureArrivee)
                    .SetProperty(m => m.HeureDepart, pointage.HeureDepart)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePointage")
        .WithGroupName("rapports");

        group.MapPost("/", async ([FromBody] Pointage pointage, [FromServices] CsepicerieDbContext db) =>
        {
            db.Pointages.Add(pointage);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Pointage/{pointage.IdPointage}",pointage);
        })
        .WithName("CreatePointage")
        .WithGroupName("rapports");

        group.MapDelete("/{idpointage}", async Task<Results<Ok, NotFound>> (int idpointage, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Pointages
                .Where(model => model.IdPointage == idpointage)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePointage")
        .WithGroupName("rapports");
    }
}
