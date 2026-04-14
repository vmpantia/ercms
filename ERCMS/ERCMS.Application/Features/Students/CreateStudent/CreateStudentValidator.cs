using ERCMS.Domain.Interfaces.Repositories;
using FluentValidation;

namespace ERCMS.Application.Features.Students.CreateStudent;

public sealed class CreateStudentValidator : AbstractValidator<CreateStudentDto>
{
    public CreateStudentValidator(IStudentRepository studentRepository)
    {
        RuleFor(csd => csd.FirstName).NotEmpty();
        RuleFor(csd => csd.LastName).NotEmpty();
        RuleFor(csd => csd.PhoneNumber).NotEmpty();
        RuleFor(csd => csd.EmailAddress).EmailAddress().NotEmpty();
        RuleFor(csd => csd.Address.Line1).NotEmpty();
        RuleFor(csd => csd.Address.Barangay).NotEmpty();
        RuleFor(csd => csd.Address.City).NotEmpty();
        RuleFor(csd => csd.Address.Province).NotEmpty();
        RuleFor(csd => csd.Address.Country).NotEmpty();
        RuleFor(csd => csd.Address.ZipCode).GreaterThan(0);
        
        RuleFor(csd => csd)
            .MustAsync(async (csd, ct) =>
            {
                var student = await studentRepository.GetOneAsync(s => s.FirstName == csd.FirstName && s.LastName == csd.LastName, ct);
                return student == null;
            })
            .WithMessage("Student first name and last name is already exist.");
    }
}