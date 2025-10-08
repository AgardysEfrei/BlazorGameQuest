using Grpc.Core;
using Authentification;

namespace AuthentificationService.Services;

public class AuthentificationService(ILogger<AuthentificationService> logger) : Authentification.AuthentificationService.AuthentificationServiceBase
{
    private readonly ILogger<AuthentificationService> _logger = logger;

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}