using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Domain.Requests;
using ERCMS.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace ERCMS.Application.Users.GetUsers;

public sealed class GetUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery>
{
    public async Task<Result> HandleAsync(GetUsersQuery request, CancellationToken cancellationToken = default)
    {
        var users = await userRepository
            .GetAll()
            .ToListAsync(cancellationToken);

        return Result.Success(users);
    }
}