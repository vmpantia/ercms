using ERCMS.Domain.Requests;

namespace ERCMS.Application.Users.RegisterUser;

public record RegisterUserCommand(RegisterUserDto User) : ICommand;