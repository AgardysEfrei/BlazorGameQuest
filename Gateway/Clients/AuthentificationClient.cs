using Gateway.Interfaces;

namespace Gateway.Clients;

public class AuthentificationClient : IAuthentificationClient
{
    private readonly ILogger<AuthentificationClient> _logger;
    private readonly Authentification.AuthentificationService.AuthentificationServiceClient _client;

    public AuthentificationClient(ILogger<AuthentificationClient> logger,
        Authentification.AuthentificationService.AuthentificationServiceClient client)
    {
        _logger = logger;
        _client = client;
    }
    
}