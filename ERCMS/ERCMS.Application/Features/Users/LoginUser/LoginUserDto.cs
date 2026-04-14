namespace ERCMS.Application.Features.Users.LoginUser;

public sealed class LoginUserDto
{
    public required string UsernameOrEmail { get; set; }
    public required string Password { get; set; }
}