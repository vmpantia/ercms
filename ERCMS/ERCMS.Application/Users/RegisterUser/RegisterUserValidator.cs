using ERCMS.Domain.Interfaces.Repositories;
using FluentValidation;

namespace ERCMS.Application.Users.RegisterUser;

public sealed class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator(IUserRepository userRepository)
    {
        RuleFor(rud => rud.Email).NotEmpty().EmailAddress();
        RuleFor(rud => rud.Username).NotEmpty();
        RuleFor(rud => rud.Password).NotEmpty();
        RuleFor(rud => rud.FirstName).NotEmpty();
        RuleFor(rud => rud.LastName).NotEmpty();
        
        RuleFor(rud => rud)
            .MustAsync(async (rud, ct) =>
            {
                var user = await userRepository.GetOneAsync(u => (u.Username == rud.Username) || (u.Email == rud.Email), ct);
                return user == null;
            })
            .WithMessage("Username or email is already used by other user.");
    }
}