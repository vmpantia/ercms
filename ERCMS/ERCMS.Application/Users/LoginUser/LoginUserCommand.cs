using ERCMS.Domain.Requests;

namespace ERCMS.Application.Users.LoginUser;

public sealed record LoginUserCommand(LoginUserDto Login) : ICommand;