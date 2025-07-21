using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Endpoints;

public static class ClientEndpoints
{
    public static void MapClientEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Client");

        group.MapGet("/", async ([FromServices] CsepicerieDbContext db) =>
        {
            return await db.Clients.ToListAsync();
        })
        .WithName("GetAllClients")
        .WithGroupName("transactions");

        group.MapGet("/{idclient}", async Task<Results<Ok<Client>, NotFound>> (int idclient,[FromServices] CsepicerieDbContext db) =>
        {
            return await db.Clients.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdClient == idclient)
                is Client model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetClientById")
        .WithGroupName("transactions");

        group.MapPut("/{idclient}", async Task<Results<Ok, NotFound>> (int idclient, [FromBody] Client client,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Clients
                .Where(model => model.IdClient == idclient)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdClient, client.IdClient)
                    .SetProperty(m => m.Nom, client.Nom)
                    .SetProperty(m => m.Telephone, client.Telephone)
                    .SetProperty(m => m.Email, client.Email)
                    .SetProperty(m => m.Credit, client.Credit)
                    .SetProperty(m => m.DateInscription, client.DateInscription)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateClient")
        .WithGroupName("transactions");

        group.MapPost("/", async ( [FromBody] Client client, [FromServices] CsepicerieDbContext db) =>
        {
            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Client/{client.IdClient}",client);
        })
        .WithName("CreateClient")
        .WithGroupName("transactions");

        group.MapDelete("/{idclient}", async Task<Results<Ok, NotFound>> (int idclient,[FromServices] CsepicerieDbContext db) =>
        {
            var affected = await db.Clients
                .Where(model => model.IdClient == idclient)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteClient")
        .WithGroupName("transactions");
    }
}
