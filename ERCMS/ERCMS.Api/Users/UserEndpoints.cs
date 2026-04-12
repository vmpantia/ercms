using ERCMS.Application.Users.RegisterUser;
using ERCMS.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ERCMS.Api.Users;

internal abstract class UserEndpoints
{
    public static void Map(RouteGroupBuilder api)
    {
        api.MapPost("/users/register", async ([FromBody] RegisterUserDto request, IRequestHandler<RegisterUserCommand> handler, CancellationToken cancellationToken) =>
        {
            var command = new RegisterUserCommand(request);
            var result = await handler.HandleAsync(command, cancellationToken);
            
            return Results.Ok(result);
        });
    }
}
