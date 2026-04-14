using ERCMS.Domain.Requests;

namespace ERCMS.Application.Features.Users.RegisterUser;

public sealed record RegisterUserCommand(RegisterUserDto User) : ICommand;