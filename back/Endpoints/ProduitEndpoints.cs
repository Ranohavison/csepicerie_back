using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class ProduitEndpoints
{
    public static void MapProduitEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Produit");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Produits.ToListAsync();
        })
        .WithName("GetAllProduits");

        group.MapGet("/{id}", async Task<Results<Ok<Produit>, NotFound>> (int idproduit, [FromServices] CsepicerieDbContext db) =>
        {
            return await db.Produits.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdProduit == idproduit)
                is Produit model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetProduitById");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idproduit, [FromBody] Produit produit, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Produits
                .Where(model => model.IdProduit == idproduit)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdProduit, produit.IdProduit)
                    .SetProperty(m => m.IdCategorie, produit.IdCategorie)
                    .SetProperty(m => m.CodeBarre, produit.CodeBarre)
                    .SetProperty(m => m.Nom, produit.Nom)
                    .SetProperty(m => m.PrixAchat, produit.PrixAchat)
                    .SetProperty(m => m.PrixVente, produit.PrixVente)
                    .SetProperty(m => m.Quantite, produit.Quantite)
                    .SetProperty(m => m.Unite, produit.Unite)
                    .SetProperty(m => m.SeuilMin, produit.SeuilMin)
                    .SetProperty(m => m.DateAjout, produit.DateAjout)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateProduit");

        group.MapPost("/", async ([FromBody] Produit produit, [FromServices] CsepicerieDbContext db) =>
        {
            db.Produits.Add(produit);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Produit/{produit.IdProduit}",produit);
        })
        .WithName("CreateProduit");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idproduit, [FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Produits
                .Where(model => model.IdProduit == idproduit)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteProduit");
    }
}
