using ERCMS.Application.Authentication;
using ERCMS.Domain.Interfaces.Authentication;
using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Domain.Requests;
using ERCMS.Domain.Responses;
using ERCMS.Domain.Responses.Errors;
using FluentValidation;

namespace ERCMS.Application.Features.Users.LoginUser;

public sealed class LoginUserCommandHandler(IValidator<LoginUserCommand> validator, IUserRepository userRepository, ITokenProvider tokenProvider) : IRequestHandler<LoginUserCommand>
{
    public async Task<Result> HandleAsync(LoginUserCommand request, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var user = await userRepository.GetOneAsync(u =>
                u.Username == request.Login.UsernameOrEmail || u.Email == request.Login.UsernameOrEmail,
            cancellationToken);
        if (user == null) return Result.Failed(UserError.UsernameOrEmailAddressNotFound());
        if (!PasswordHasher.Verify(user.Password, request.Login.Password)) return Result.Failed(UserError.PasswordIncorrect());

        var token = tokenProvider.GenerateAccessToken(user);

        return Result.Success(token);
    }
}