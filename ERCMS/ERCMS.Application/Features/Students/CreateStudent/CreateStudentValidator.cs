using FluentValidation;

namespace ERCMS.Application.Features.Students.CreateStudent;

public sealed class CreateStudentValidator : AbstractValidator<CreateStudentDto>
{
    public CreateStudentValidator()
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
    }
}