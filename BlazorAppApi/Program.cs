using Microsoft.EntityFrameworkCore;
using SharedModelDbContext;
using BlazorAppApi.Service;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddDbContext<BlazorQuestDbContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin() // **Change this to .WithOrigins("YOUR_BLAZOR_FRONTEND_URL") in production**
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
builder.Services.AddScoped<IAdministrateurService, AdministrateurService>();
builder.Services.AddScoped<IDonjonsService, DonjonsService>();
builder.Services.AddScoped<IJoueurService, JoueurService>();
builder.Services.AddScoped<IMonstreService, MonstreService>();
builder.Services.AddScoped<ISallesService, SallesService>();
builder.Services.AddScoped<IScorePartieService, ScorePartieService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BlazorQuestDbContext>();
    
    var pendingMigrations = context.Database.GetPendingMigrations().ToArray();

    if (pendingMigrations.Any())
    {
        await context.Database.MigrateAsync();
    }
}

app.UseCors(MyAllowSpecificOrigins);
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}