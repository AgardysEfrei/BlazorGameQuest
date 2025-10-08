using Grpc.Core;
using Score;

namespace ScoreService.Services;

public class ScoreService(ILogger<ScoreService> logger) : Score.ScoreService.ScoreServiceBase
{
    private readonly ILogger<ScoreService> _logger = logger;

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}