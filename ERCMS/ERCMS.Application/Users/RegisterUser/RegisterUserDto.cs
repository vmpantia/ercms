using ERCMS.Application.Authentication;
using ERCMS.Domain.Entities;
using ERCMS.Domain.Interfaces;

namespace ERCMS.Application.Users.RegisterUser;

public sealed class RegisterUserDto : IMappable<User>
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }

    public User Map()
    {
        var entity = new User
        {
            Id = Guid.NewGuid(),
            Username = Username,
            Email = Email,
            Password = PasswordHasher.Hash(Password),
            FirstName = FirstName,
            MiddleName = MiddleName,
            LastName = LastName
        };
        
        return entity;;
    }
}