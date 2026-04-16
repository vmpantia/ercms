using ERCMS.Domain.Interfaces.Repositories;
using FluentValidation;

namespace ERCMS.Application.Features.Students.CreateStudent;

public sealed class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator(IStudentRepository studentRepository)
    {
        RuleFor(csc => csc.Student.FirstName).NotEmpty();
        RuleFor(csc => csc.Student.LastName).NotEmpty();
        RuleFor(csc => csc.Student.PhoneNumber).NotEmpty();
        RuleFor(csc => csc.Student.EmailAddress).EmailAddress().NotEmpty();
        RuleFor(csc => csc.Student.Address.Line1).NotEmpty();
        RuleFor(csc => csc.Student.Address.Barangay).NotEmpty();
        RuleFor(csc => csc.Student.Address.City).NotEmpty();
        RuleFor(csc => csc.Student.Address.Province).NotEmpty();
        RuleFor(csc => csc.Student.Address.Country).NotEmpty();
        RuleFor(csc => csc.Student.Address.ZipCode).GreaterThan(0);
        
        RuleFor(csc => csc.Student)
            .MustAsync(async (csd, ct) =>
            {
                var student = await studentRepository.GetOneAsync(s => s.FirstName == csd.FirstName && s.LastName == csd.LastName, ct);
                return student == null;
            })
            .WithMessage("Student first name and last name is already exist.");
    }
}