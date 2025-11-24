using BlazorApp.Components;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient("Api", client =>
{
    // **IMPORTANT**: This is the URL the server-side component of Blazor will use.
    // If you are using Docker Compose, this should be the name of your API service.
    // For local testing outside of Docker, use the API's specific URL (e.g., "https://localhost:7001/").
    // Assuming your API service name in Docker is 'api-service-name':
    client.BaseAddress = new Uri("http://blazorappapi/"); 
    
    // If running locally without Docker, and your API runs on http://localhost:5001:
    // client.BaseAddress = new Uri("http://localhost:5001/");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();