using ERCMS.Api.Exceptions;

namespace ERCMS.Api.Endpoints;

public static class ApiEndpoints
{
    public static void MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        var api = app
            .MapGroup("/api")
            .AddEndpointFilter<ExceptionEndpointFilter>();

        api.MapAuthEndpoints();
        api.MapUsersEndpoints();
        api.MapStudentsEndpoints();
    }
}