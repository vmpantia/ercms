using ERCMS.Api.Extensions;
using ERCMS.Application.Users.LoginUser;
using ERCMS.Application.Users.RegisterUser;
using ERCMS.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ERCMS.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this RouteGroupBuilder api)
    {
        var auth = api.MapGroup("/auth");
        
        auth.MapPost("/login", LoginAsync).AllowAnonymous();
        auth.MapPost("/register", RegisterAsync).RequireAuthorization();
    }

    private static async Task<IResult> LoginAsync([FromBody] LoginUserDto request, IRequestHandler<LoginUserCommand> handler, CancellationToken ct)
    {
        var result = await handler.HandleAsync(new LoginUserCommand(request), ct);
        return result.MatchToResults();
    }

    private static async Task<IResult> RegisterAsync([FromBody] RegisterUserDto request, IRequestHandler<RegisterUserCommand> handler, CancellationToken ct)
    {
        var result = await handler.HandleAsync(new RegisterUserCommand(request), ct);
        return result.MatchToResults();
    }
}