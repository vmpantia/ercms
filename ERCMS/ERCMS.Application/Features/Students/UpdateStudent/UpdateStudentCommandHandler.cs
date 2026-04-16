using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Domain.Requests;
using ERCMS.Domain.Responses;
using ERCMS.Domain.Responses.Errors;
using FluentValidation;

namespace ERCMS.Application.Features.Students.UpdateStudent;

public sealed class UpdateStudentCommandHandler(IValidator<UpdateStudentCommand> validator, IStudentRepository studentRepository) : IRequestHandler<UpdateStudentCommand>
{
    public async Task<Result> HandleAsync(UpdateStudentCommand request, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var studentToUpdate = await studentRepository.GetOneAsync(request.Id, cancellationToken);
        if (studentToUpdate == null) return Result.Failed(StudentError.NotFound(request.Id));

        var updatedStudent = StudentMappings.Map(studentToUpdate, request.Student);
        await studentRepository.UpdateAsync(updatedStudent, cancellationToken);

        return Result.Success(updatedStudent.Map());
    }
}