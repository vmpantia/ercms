using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Domain.Requests;
using ERCMS.Domain.Responses;
using ERCMS.Domain.Responses.Errors;

namespace ERCMS.Application.Features.Students.DeleteStudentById;

public sealed class DeleteStudentByIdCommandHandler(IStudentRepository studentRepository) : IRequestHandler<DeleteStudentByIdCommand>
{
    public async Task<Result> HandleAsync(DeleteStudentByIdCommand request, CancellationToken cancellationToken = default)
    {
        var student = await studentRepository.GetOneAsync(request.Id, cancellationToken);

        if (student == null) return Result.Failed(StudentError.NotFound(request.Id));
        
        await studentRepository.DeleteAsync(student, cancellationToken);
        
        return Result.Success();
    }
}