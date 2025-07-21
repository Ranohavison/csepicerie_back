using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class RoleEndpoints
{
    public static void MapRoleEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Role");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Roles.ToListAsync();
        })
        .WithName("GetAllRoles")
        .WithGroupName("parametres");

        group.MapGet("/{idrole}", async Task<Results<Ok<Role>, NotFound>> (int idrole, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.Roles.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdRole == idrole)
                is Role model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetRoleById")
        .WithGroupName("parametres");

        group.MapPut("/{idrole}", async Task<Results<Ok, NotFound>> (int idrole, [FromBody] Role role, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Roles
                .Where(model => model.IdRole == idrole)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdRole, role.IdRole)
                    .SetProperty(m => m.NomRole, role.NomRole)
                    .SetProperty(m => m.Description, role.Description)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateRole")
        .WithGroupName("parametres");

        group.MapPost("/", async ([FromBody] Role role, [FromServices] CsepicerieDbContext db) =>
        {
            db.Roles.Add(role);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Role/{role.IdRole}",role);
        })
        .WithName("CreateRole")
        .WithGroupName("parametres");

        group.MapDelete("/{idrole}", async Task<Results<Ok, NotFound>> (int idrole, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Roles
                .Where(model => model.IdRole == idrole)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteRole")
        .WithGroupName("parametres");
    }
}
