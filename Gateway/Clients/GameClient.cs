using Authentification;
using Gateway.Interfaces;

namespace Gateway.Clients;

public class GameClient : IGameClient
{
    private readonly ILogger<GameClient> _logger;
    private readonly Game.GameService.GameServiceClient _client;

    public GameClient(ILogger<GameClient> logger, Game.GameService.GameServiceClient client)
    {
        _logger = logger;
        _client = client;
    }
}