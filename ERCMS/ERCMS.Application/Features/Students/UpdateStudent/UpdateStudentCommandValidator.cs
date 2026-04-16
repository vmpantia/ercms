using ERCMS.Domain.Interfaces.Repositories;
using FluentValidation;

namespace ERCMS.Application.Features.Students.UpdateStudent;

public sealed class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator(IStudentRepository studentRepository)
    {
        RuleFor(usc => usc.Student.FirstName).NotEmpty();
        RuleFor(usc => usc.Student.LastName).NotEmpty();
        RuleFor(usc => usc.Student.PhoneNumber).NotEmpty();
        RuleFor(usc => usc.Student.EmailAddress).EmailAddress().NotEmpty();
        RuleFor(usc => usc.Student.Address.Line1).NotEmpty();
        RuleFor(usc => usc.Student.Address.Barangay).NotEmpty();
        RuleFor(usc => usc.Student.Address.City).NotEmpty();
        RuleFor(usc => usc.Student.Address.Province).NotEmpty();
        RuleFor(usc => usc.Student.Address.Country).NotEmpty();
        RuleFor(usc => usc.Student.Address.ZipCode).GreaterThan(0);
        
        RuleFor(usc => usc)
            .MustAsync(async (usc, ct) =>
            {
                var student = await studentRepository
                    .GetOneAsync(s => s.Id != usc.Id &&
                                      s.FirstName == usc.Student.FirstName && 
                                      s.LastName == usc.Student.LastName,
                        ct);
                return student == null;
            })
            .WithMessage("Student first name and last name is already exist.");
    }
}