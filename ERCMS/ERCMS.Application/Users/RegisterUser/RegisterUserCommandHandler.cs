using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Domain.Requests;
using ERCMS.Domain.Responses;

namespace ERCMS.Application.Users.RegisterUser;

public sealed class RegisterUserCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterUserCommand>
{
    public async Task<Result> HandleAsync(RegisterUserCommand request, CancellationToken cancellationToken = default)
    {
        var entity = request.User.Map();
        
        var user = await userRepository.CreateAsync(entity, cancellationToken);

        return Result.Success(user);
    }
}