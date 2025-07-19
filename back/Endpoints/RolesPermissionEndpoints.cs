using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class RolesPermissionEndpoints
{
    public static void MapRolesPermissionEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/RolesPermission");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.RolesPermissions.ToListAsync();
        })
        .WithName("GetAllRolesPermissions");

        group.MapGet("/{id}", async Task<Results<Ok<RolesPermission>, NotFound>> (int id, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.RolesPermissions.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is RolesPermission model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetRolesPermissionById");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromBody] RolesPermission rolesPermission, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.RolesPermissions
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, rolesPermission.Id)
                    .SetProperty(m => m.IdRole, rolesPermission.IdRole)
                    .SetProperty(m => m.IdPermission, rolesPermission.IdPermission)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateRolesPermission");

        group.MapPost("/", async ([FromBody] RolesPermission rolesPermission, [FromServices] CsepicerieDbContext db) =>
        {
            db.RolesPermissions.Add(rolesPermission);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/RolesPermission/{rolesPermission.Id}",rolesPermission);
        })
        .WithName("CreateRolesPermission");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.RolesPermissions
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteRolesPermission");
    }
}
