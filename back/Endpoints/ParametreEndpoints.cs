using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class ParametreEndpoints
{
    public static void MapParametreEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Parametre");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Parametres.ToListAsync();
        })
        .WithName("GetAllParametres");

        group.MapGet("/{id}", async Task<Results<Ok<Parametre>, NotFound>> (int idparam,[FromServices] CsepicerieDbContext db) =>
        {
            return await db.Parametres.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdParam == idparam)
                is Parametre model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetParametreById");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idparam, [FromBody] Parametre parametre,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Parametres
                .Where(model => model.IdParam == idparam)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdParam, parametre.IdParam)
                    .SetProperty(m => m.Cle, parametre.Cle)
                    .SetProperty(m => m.Valeur, parametre.Valeur)
                    .SetProperty(m => m.Description, parametre.Description)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateParametre");

        group.MapPost("/", async ( [FromBody] Parametre parametre,[FromServices] CsepicerieDbContext db) =>
        {
            db.Parametres.Add(parametre);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Parametre/{parametre.IdParam}",parametre);
        })
        .WithName("CreateParametre");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idparam,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Parametres
                .Where(model => model.IdParam == idparam)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteParametre");
    }
}
