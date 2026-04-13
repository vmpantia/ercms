using ERCMS.Domain.Requests;

namespace ERCMS.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(RegisterUserDto Register) : ICommand;