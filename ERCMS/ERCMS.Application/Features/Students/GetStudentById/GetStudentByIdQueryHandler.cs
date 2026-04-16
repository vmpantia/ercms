using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Domain.Requests;
using ERCMS.Domain.Responses;
using ERCMS.Domain.Responses.Errors;

namespace ERCMS.Application.Features.Students.GetStudentById;

public sealed class GetStudentByIdQueryHandler(IStudentRepository studentRepository) : IRequestHandler<GetStudentByIdQuery>
{
    public async Task<Result> HandleAsync(GetStudentByIdQuery request, CancellationToken cancellationToken = default)
    {
        var student = await studentRepository.GetOneAsync(request.Id, cancellationToken);
        if (student == null) return Result.Failed(StudentError.NotFound(request.Id));

        return Result.Success(student.Map());
    }
}