using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class DetailsAchatEndpoints
{
    public static void MapDetailsAchatEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/DetailsAchat");

        group.MapGet("/", async ( [FromServices] CsepicerieDbContext db) =>
        {
            return await db.DetailsAchats.ToListAsync();
        })
        .WithName("GetAllDetailsAchats");

        group.MapGet("/{id}", async Task<Results<Ok<DetailsAchat>, NotFound>> (int id, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.DetailsAchats.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is DetailsAchat model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDetailsAchatById");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromBody] DetailsAchat detailsAchat, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.DetailsAchats
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, detailsAchat.Id)
                    .SetProperty(m => m.IdProduit, detailsAchat.IdProduit)
                    .SetProperty(m => m.IdAchat, detailsAchat.IdAchat)
                    .SetProperty(m => m.Quantity, detailsAchat.Quantity)
                    .SetProperty(m => m.PrixUnitaire, detailsAchat.PrixUnitaire)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDetailsAchat");

        group.MapPost("/", async ( [FromBody] DetailsAchat detailsAchat, [FromServices] CsepicerieDbContext db) =>
        {
            db.DetailsAchats.Add(detailsAchat);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/DetailsAchat/{detailsAchat.Id}",detailsAchat);
        })
        .WithName("CreateDetailsAchat");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.DetailsAchats
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDetailsAchat");
    }
}
