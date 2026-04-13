using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Domain.Requests;
using ERCMS.Domain.Responses;
using FluentValidation;

namespace ERCMS.Application.Users.RegisterUser;

public sealed class RegisterUserCommandHandler(IValidator<RegisterUserDto> validator, IUserRepository userRepository) : IRequestHandler<RegisterUserCommand>
{
    public async Task<Result> HandleAsync(RegisterUserCommand request, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAndThrowAsync(request.User, cancellationToken);
        
        var entity = request.User.Map();
        
        var user = await userRepository.CreateAsync(entity, cancellationToken);

        return Result.Success(user);
    }
}