using JAXPORT.Models;
using JAXPORT.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register DB service
builder.Services.AddDbContext<JaxportDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("JaxportDatabase"),
        npgsqlOptions => npgsqlOptions.CommandTimeout(5)
    ));

builder.Services.AddScoped<IPortService, PortService>();        // Register Port Endpoint service
builder.Services.AddScoped<ISupportService, SupportService>();        // Register Support service

var app = builder.Build();

// DB Healthcheck API
app.MapGet("/api/health/database", async (ISupportService _ss) =>
{
    var healthCheckResult = await _ss.GetDbHealthStatusAsync();
    if (healthCheckResult.Success)
    {
        return Results.Ok(healthCheckResult.Data);
    }
    else
    {
        return Results.InternalServerError();
    }
});



// Development tools
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Serve wwwroot/index.html, CSS, JS, etc.
app.UseDefaultFiles();
app.UseStaticFiles();

// API endpoints
app.MapControllers();

app.Run();