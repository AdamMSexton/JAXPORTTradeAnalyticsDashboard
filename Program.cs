var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

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