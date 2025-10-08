using Grpc.Core;
using User;

namespace UserService.Services;

public class UserService(ILogger<UserService> logger) : User.UserService.UserServiceBase
{
    private readonly ILogger<UserService> _logger = logger;

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}