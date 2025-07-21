using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class StockMouvementEndpoints
{
    public static void MapStockMouvementEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/StockMouvement");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.StockMouvements.ToListAsync();
        })
        .WithName("GetAllStockMouvements")
        .WithGroupName("catalogue");

        group.MapGet("/{id}", async Task<Results<Ok<StockMouvement>, NotFound>> (int id, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.StockMouvements.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is StockMouvement model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStockMouvementById")
        .WithGroupName("catalogue");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromBody] StockMouvement stockMouvement, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.StockMouvements
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, stockMouvement.Id)
                    .SetProperty(m => m.IdProduit, stockMouvement.IdProduit)
                    .SetProperty(m => m.TypeMouvement, stockMouvement.TypeMouvement)
                    .SetProperty(m => m.Quantite, stockMouvement.Quantite)
                    .SetProperty(m => m.DateMouvement, stockMouvement.DateMouvement)
                    .SetProperty(m => m.Motif, stockMouvement.Motif)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStockMouvement")
        .WithGroupName("catalogue");

        group.MapPost("/", async ([FromBody] StockMouvement stockMouvement, [FromServices] CsepicerieDbContext db) =>
        {
            db.StockMouvements.Add(stockMouvement);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/StockMouvement/{stockMouvement.Id}",stockMouvement);
        })
        .WithName("CreateStockMouvement")
        .WithGroupName("catalogue");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.StockMouvements
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStockMouvement")
        .WithGroupName("catalogue");
    }
}
