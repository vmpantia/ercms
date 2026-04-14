using ERCMS.Api.Extensions;
using ERCMS.Application.Features.Students.CreateStudent;
using ERCMS.Application.Features.Students.GetStudentById;
using ERCMS.Application.Features.Students.GetStudents;
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
        users.MapGet("/", GetStudentsAsync);
        users.MapGet("/{id}", GetStudentByIdAsync);
    }

    private static async Task<IResult> CreateStudentAsync([FromBody] CreateStudentDto request, [FromServices] IRequestHandler<CreateStudentCommand> handler, CancellationToken ct)
    {
        var result = await handler.HandleAsync(new CreateStudentCommand(request), ct);
        return result.MatchToResults();
    }

    private static async Task<IResult> GetStudentsAsync([FromServices] IRequestHandler<GetStudentsQuery> handler, CancellationToken ct)
    {
        var result = await handler.HandleAsync(new GetStudentsQuery(), ct);
        return result.MatchToResults();
    }

    private static async Task<IResult> GetStudentByIdAsync(Guid id, [FromServices] IRequestHandler<GetStudentByIdQuery> handler, CancellationToken ct)
    {
        var result = await handler.HandleAsync(new GetStudentByIdQuery(id), ct);
        return result.MatchToResults();
    }
}