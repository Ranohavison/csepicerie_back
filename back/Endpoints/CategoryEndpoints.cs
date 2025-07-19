using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Category");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Categories.ToListAsync();
        })
        .WithName("GetAllCategories");

        group.MapGet("/{id}", async Task<Results<Ok<Category>, NotFound>> (int idcategorie,[FromServices] CsepicerieDbContext db) =>
        {
            return await db.Categories.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdCategorie == idcategorie)
                is Category model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCategoryById");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idcategorie,[FromBody] Category category,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Categories
                .Where(model => model.IdCategorie == idcategorie)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdCategorie, category.IdCategorie)
                    .SetProperty(m => m.Nom, category.Nom)
                    .SetProperty(m => m.Description, category.Description)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCategory");

        group.MapPost("/", async ([FromBody] Category category,[FromServices] CsepicerieDbContext db) =>
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Category/{category.IdCategorie}",category);
        })
        .WithName("CreateCategory");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idcategorie,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Categories
                .Where(model => model.IdCategorie == idcategorie)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCategory");
    }
}
