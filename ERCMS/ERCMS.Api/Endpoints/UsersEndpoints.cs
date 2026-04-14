using ERCMS.Api.Extensions;
using ERCMS.Application.Features.Users.GetUsers;
using ERCMS.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ERCMS.Api.Endpoints;

internal static class UsersEndpoints
{
    public static void MapUsersEndpoints(this RouteGroupBuilder api)
    {
        var users = api
            .MapGroup("/users")
            .RequireAuthorization();
        
        users.MapGet("/", GetUsersAsync);
    }

    private static async Task<IResult> GetUsersAsync([FromServices] IRequestHandler<GetUsersQuery> handler, CancellationToken ct)
    {
        var result = await handler.HandleAsync(new GetUsersQuery(), ct);
        return result.MatchToResults();
    }
}
