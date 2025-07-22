using back.AchatEndpoints;
using back.Endpoints;
using back.Models;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
// using DotNetEnv;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CsepicerieDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("auth", new() { Title = "Authentification", Version = "v1" });
    c.SwaggerDoc("transactions", new() { Title = "Transactions", Version = "v1" });
    c.SwaggerDoc("parametres", new() { Title = "Paramètres", Version = "v1" });
    c.SwaggerDoc("catalogue", new() { Title = "Catalogue", Version = "v1" });
    c.SwaggerDoc("sauvegarde", new() { Title = "Sauvegarde", Version = "v1" });

    c.DocInclusionPredicate((groupName, apiDesc) =>
    {
        var group = apiDesc.GroupName;
        return group != null && group.Equals(groupName, StringComparison.OrdinalIgnoreCase);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/auth/swagger.json", "Authentification");
        c.SwaggerEndpoint("/swagger/transactions/swagger.json", "Transactions");
        c.SwaggerEndpoint("/swagger/parametres/swagger.json", "Paramètres");
        c.SwaggerEndpoint("/swagger/catalogue/swagger.json", "Catalogue");
        c.SwaggerEndpoint("/swagger/sauvegarde/swagger.json", "Sauvegarde");
    });
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapGet("/test", () =>
{
    var myVariable = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
    return $"MY_VARIABLE: {myVariable}";
});

app.MapAchatEndpoints();

app.MapCategoryEndpoints();

app.MapClientEndpoints();

app.MapDepenseEndpoints();

app.MapDetailsVenteEndpoints();

app.MapDetailsAchatEndpoints();

app.MapFournisseurEndpoints();

app.MapParametreEndpoints();

app.MapPermissionEndpoints();

app.MapPointageEndpoints();

app.MapProduitEndpoints();

app.MapRapportEndpoints();

app.MapRoleEndpoints();

app.MapRolesPermissionEndpoints();

app.MapSauvegardeEndpoints();

app.MapStockMouvementEndpoints();

app.MapUtilisateurEndpoints();

app.MapVenteEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}