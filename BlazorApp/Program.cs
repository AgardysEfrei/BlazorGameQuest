using BlazorApp.Components;
using Microsoft.AspNetCore.DataProtection;
using BlazorAppApi.Service;
using SharedModels;

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
    client.BaseAddress = new Uri("http://blazorappapi:8080/"); 
    
});

var handler = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
};
var httpClient = new HttpClient(handler);

builder.Services.AddSingleton(httpClient);
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        var backendIdpUrl = "http://keycloak:8080/realms/myrealm";
        var clientIdpUrl = "http://localhost:8082/realms/myrealm";

        options.Configuration = new()
        {
            Issuer = backendIdpUrl,
            AuthorizationEndpoint = $"{clientIdpUrl}/protocol/openid-connect/auth",
            TokenEndpoint = $"{backendIdpUrl}/protocol/openid-connect/token",
            JwksUri = $"{backendIdpUrl}/protocol/openid-connect/certs",
            JsonWebKeySet = FetchJwks($"{backendIdpUrl}/protocol/openid-connect/certs"),
            EndSessionEndpoint = $"{clientIdpUrl}/protocol/openid-connect/logout"
        };

        foreach (var key in options.Configuration.JsonWebKeySet.GetSigningKeys())
        {
            options.Configuration.SigningKeys.Add(key);
        }

        options.ClientId = "blazor-gamequest";
        options.TokenValidationParameters.ValidIssuers = [clientIdpUrl, backendIdpUrl];
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.RequireHttpsMetadata = false;
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
        options.MapInboundClaims = true;

        // options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

JsonWebKeySet FetchJwks(string url)
{
    var result = httpClient.GetAsync(url).Result;
    if (!result.IsSuccessStatusCode || result.Content is null)
    {
        throw new Exception(
            $"Getting token issuers (Keycloaks) JWKS from {url} failed. Status code {result.StatusCode}");
    }

    var jwks = result.Content.ReadAsStringAsync().Result;
    return new JsonWebKeySet(jwks);
}

builder.Services.AddAuthorization();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapPost("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await context.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
});

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();