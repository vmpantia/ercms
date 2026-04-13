using ERCMS.Application.Users.GetUsers;
using ERCMS.Application.Users.LoginUser;
using ERCMS.Application.Users.RegisterUser;
using ERCMS.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ERCMS.Api.Users;

internal abstract class UserEndpoints
{
    public static void Map(RouteGroupBuilder api)
    {
        api.MapPost("/auth/login", async ([FromBody] LoginUserDto request, IRequestHandler<LoginUserCommand> handler, CancellationToken cancellationToken) =>
        {
            var command = new LoginUserCommand(request);
            var result = await handler.HandleAsync(command, cancellationToken);
            
            return Results.Ok(result);
        }).AllowAnonymous();
        
        api.MapPost("/auth/register", async ([FromBody] RegisterUserDto request, IRequestHandler<RegisterUserCommand> handler, CancellationToken cancellationToken) =>
        {
            var command = new RegisterUserCommand(request);
            var result = await handler.HandleAsync(command, cancellationToken);
            
            return Results.Ok(result);
        }).RequireAuthorization();
        
        api.MapGet("/users", async (IRequestHandler<GetUsersQuery> handler, CancellationToken cancellationToken) =>
        {
            var query = new GetUsersQuery();
            var result = await handler.HandleAsync(query, cancellationToken);
            
            return Results.Ok(result);
        }).RequireAuthorization();
    }
}
