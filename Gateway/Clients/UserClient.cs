using Gateway.Interfaces;

namespace Gateway.Clients;

public class UserClient : IUserClient
{
    private readonly ILogger<UserClient> _logger;
    private readonly Score.ScoreService.ScoreServiceClient _client;

    public UserClient(ILogger<UserClient> logger, Score.ScoreService.ScoreServiceClient client)
    {
        _logger = logger;
        _client = client;
    }
}