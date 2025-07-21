using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class UtilisateurEndpoints
{
    public static void MapUtilisateurEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Utilisateur");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Utilisateurs.ToListAsync();
        })
        .WithName("GetAllUtilisateurs")
        .WithGroupName("auth");

        group.MapGet("/{idutilisateur}", async Task<Results<Ok<Utilisateur>, NotFound>> (int idutilisateur, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.Utilisateurs.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdUtilisateur == idutilisateur)
                is Utilisateur model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetUtilisateurById")
        .WithGroupName("auth");

        group.MapPut("/{idutilisateur}", async Task<Results<Ok, NotFound>> (int idutilisateur, [FromBody] Utilisateur utilisateur, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Utilisateurs
                .Where(model => model.IdUtilisateur == idutilisateur)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdUtilisateur, utilisateur.IdUtilisateur)
                    .SetProperty(m => m.IdRole, utilisateur.IdRole)
                    .SetProperty(m => m.Nom, utilisateur.Nom)
                    .SetProperty(m => m.Prenom, utilisateur.Prenom)
                    .SetProperty(m => m.Email, utilisateur.Email)
                    .SetProperty(m => m.MotDePasse, utilisateur.MotDePasse)
                    .SetProperty(m => m.Statut, utilisateur.Statut)
                    .SetProperty(m => m.DateCreation, utilisateur.DateCreation)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateUtilisateur")
        .WithGroupName("auth");

        group.MapPost("/", async ([FromBody] Utilisateur utilisateur, [FromServices] CsepicerieDbContext db) =>
        {
            db.Utilisateurs.Add(utilisateur);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Utilisateur/{utilisateur.IdUtilisateur}",utilisateur);
        })
        .WithName("CreateUtilisateur")
        .WithGroupName("auth");

        group.MapDelete("/{idutilisateur}", async Task<Results<Ok, NotFound>> (int idutilisateur, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Utilisateurs
                .Where(model => model.IdUtilisateur == idutilisateur)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteUtilisateur")
        .WithGroupName("auth");
    }
}
