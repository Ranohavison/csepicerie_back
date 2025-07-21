using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class PermissionEndpoints
{
    public static void MapPermissionEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Permission");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Permissions.ToListAsync();
        })
        .WithName("GetAllPermissions")
        .WithGroupName("parametres");

        group.MapGet("/{idpermission}", async Task<Results<Ok<Permission>, NotFound>> (int idpermission, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.Permissions.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdPermission == idpermission)
                is Permission model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPermissionById")
        .WithGroupName("parametres");

        group.MapPut("/{idpermission}", async Task<Results<Ok, NotFound>> (int idpermission, [FromBody] Permission permission, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Permissions
                .Where(model => model.IdPermission == idpermission)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdPermission, permission.IdPermission)
                    .SetProperty(m => m.NomModule, permission.NomModule)
                    .SetProperty(m => m.Action, permission.Action)
                    .SetProperty(m => m.Description, permission.Description)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePermission")
        .WithGroupName("parametres");

        group.MapPost("/", async ([FromBody] Permission permission, [FromServices] CsepicerieDbContext db) =>
        {
            db.Permissions.Add(permission);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Permission/{permission.IdPermission}",permission);
        })
        .WithName("CreatePermission")
        .WithGroupName("parametres");

        group.MapDelete("/{idpermission}", async Task<Results<Ok, NotFound>> (int idpermission, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Permissions
                .Where(model => model.IdPermission == idpermission)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePermission")
        .WithGroupName("parametres");
    }
}
