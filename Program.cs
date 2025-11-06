using ContosoPizza.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ContosoPizzaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ContosoPizzaContext"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ContosoPizzaContext"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
var context = services.GetRequiredService<ContosoPizzaContext>();
await ContosoPizzaContextSeed.SeedAsync(context);

try
{
    await context.Database.MigrateAsync();
    await ContosoPizzaContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB.");
}


app.Run();
