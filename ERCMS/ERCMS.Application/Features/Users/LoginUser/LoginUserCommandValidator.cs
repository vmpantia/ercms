using FluentValidation;

namespace ERCMS.Application.Features.Users.LoginUser;

public sealed class LoginUserCommandValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserCommandValidator()
    {
        RuleFor(rud => rud.UsernameOrEmail).NotEmpty();
        RuleFor(rud => rud.Password).NotEmpty();
    }
}