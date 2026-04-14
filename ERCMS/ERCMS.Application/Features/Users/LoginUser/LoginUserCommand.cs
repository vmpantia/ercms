using ERCMS.Domain.Requests;

namespace ERCMS.Application.Features.Users.LoginUser;

public sealed record LoginUserCommand(LoginUserDto Login) : ICommand;