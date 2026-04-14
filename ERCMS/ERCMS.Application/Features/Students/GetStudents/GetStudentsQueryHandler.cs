using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Domain.Requests;
using ERCMS.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace ERCMS.Application.Features.Students.GetStudents;

public sealed class GetStudentsQueryHandler(IStudentRepository studentRepository) : IRequestHandler<GetStudentsQuery>
{
    public async Task<Result> HandleAsync(GetStudentsQuery request, CancellationToken cancellationToken = default)
    {
        var students = await studentRepository
            .GetAll()
            .ToListAsync(cancellationToken);

        return Result.Success(students.Select(s => s.Map()));
    }
}