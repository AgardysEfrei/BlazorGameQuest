using Gateway.Interfaces;

namespace Gateway.Clients;

public class ScoreClient : IScoreClient
{
    private readonly ILogger<ScoreClient> _logger;
    private readonly Score.ScoreService.ScoreServiceClient _client;

    public ScoreClient(ILogger<ScoreClient> logger, Score.ScoreService.ScoreServiceClient client)
    {
        _logger = logger;
        _client = client;
    }
}