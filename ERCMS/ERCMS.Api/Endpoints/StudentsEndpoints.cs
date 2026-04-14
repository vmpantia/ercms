using ERCMS.Api.Extensions;
using ERCMS.Application.Features.Students.CreateStudent;
using ERCMS.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ERCMS.Api.Endpoints;

internal static class StudentsEndpoints
{
    public static void MapStudentsEndpoints(this RouteGroupBuilder api)
    {
        var users = api
            .MapGroup("/students")
            .RequireAuthorization();
        
        users.MapPost("/", CreateStudentAsync);
    }

    private static async Task<IResult> CreateStudentAsync([FromBody] CreateStudentDto request, IRequestHandler<CreateStudentCommand> handler, CancellationToken ct)
    {
        var result = await handler.HandleAsync(new CreateStudentCommand(request), ct);
        return result.MatchToResults();
    }
}