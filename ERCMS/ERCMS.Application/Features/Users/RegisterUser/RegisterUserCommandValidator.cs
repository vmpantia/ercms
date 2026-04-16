using ERCMS.Domain.Interfaces.Repositories;
using FluentValidation;

namespace ERCMS.Application.Features.Users.RegisterUser;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator(IUserRepository userRepository)
    {
        RuleFor(ruc => ruc.User.Email).NotEmpty().EmailAddress();
        RuleFor(ruc => ruc.User.Username).NotEmpty();
        RuleFor(ruc => ruc.User.Password).NotEmpty();
        RuleFor(ruc => ruc.User.FirstName).NotEmpty();
        RuleFor(ruc => ruc.User.LastName).NotEmpty();
        
        RuleFor(ruc => ruc.User)
            .MustAsync(async (rud, ct) =>
            {
                var user = await userRepository.GetOneAsync(u => (u.Username == rud.Username) || (u.Email == rud.Email), ct);
                return user == null;
            })
            .WithMessage("Username or email is already used by other user.");
    }
}