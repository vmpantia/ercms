using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Domain.Requests;
using ERCMS.Domain.Responses;
using FluentValidation;

namespace ERCMS.Application.Features.Students.CreateStudent;

public sealed class CreateStudentCommandHandler(IValidator<CreateStudentDto> validator, IStudentRepository studentRepository) : IRequestHandler<CreateStudentCommand>
{
    public async Task<Result> HandleAsync(CreateStudentCommand request, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAndThrowAsync(request.Student, cancellationToken);

        var entity = request.Student.Map();
        
        var student = await studentRepository.CreateAsync(entity, cancellationToken);

        return Result.Success(student.Map());
    }
}