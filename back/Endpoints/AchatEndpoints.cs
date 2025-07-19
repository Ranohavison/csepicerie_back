using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.AchatEndpoints;

public static class AchatEndpoints
{
    public static void MapAchatEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Achat");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Achats.ToListAsync();
        })
        .WithName("GetAllAchats");

        group.MapGet("/{id}", async Task<Results<Ok<Achat>, NotFound>> (int idachat, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.Achats.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdAchat == idachat)
                is Achat model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAchatById");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idachat, [FromBody] Achat achat, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Achats
                .Where(model => model.IdAchat == idachat)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdAchat, achat.IdAchat)
                    .SetProperty(m => m.IdFournisseur, achat.IdFournisseur)
                    .SetProperty(m => m.DateAchat, achat.DateAchat)
                    .SetProperty(m => m.Total, achat.Total)
                    .SetProperty(m => m.Status, achat.Status)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAchat");

        group.MapPost("/", async ([FromBody] Achat achat,[FromServices] CsepicerieDbContext db) =>
            {
                db.Achats.Add(achat);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/Achat/{achat.IdAchat}", achat);
            })
            .WithName("CreateAchat");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idachat,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Achats
                .Where(model => model.IdAchat == idachat)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAchat");
    }
}
