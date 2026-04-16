using FluentValidation;

namespace ERCMS.Application.Features.Users.LoginUser;

public sealed class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(luc => luc.Login.UsernameOrEmail).NotEmpty();
        RuleFor(luc => luc.Login.Password).NotEmpty();
    }
}