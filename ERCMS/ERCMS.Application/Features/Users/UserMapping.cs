using ERCMS.Application.Authentication;
using ERCMS.Application.Features.Users.RegisterUser;
using ERCMS.Domain.Entities;
using ERCMS.Domain.Enums;

namespace ERCMS.Application.Features.Users;

public static class UserMapping
{
    public static UserDto Map(this User entity)
    {
        var dto = new UserDto
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            FirstName = entity.FirstName,
            MiddleName = entity.MiddleName,
            LastName = entity.LastName,
            Status = entity.Status,
            LastModifiedAtUtc = entity.ModifiedAtUtc ?? entity.CreatedAtUc,
            LastModifiedBy = entity.ModifiedBy ?? entity.CreatedBy
        };

        return dto;
    }

    public static User Map(this RegisterUserDto dto)
    {
        var entity = new User
        {
            Id = Guid.NewGuid(),
            Username = dto.Username,
            Email = dto.Email,
            Password = PasswordHasher.Hash(dto.Password),
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Status = CommonStatus.Enabled
        };
        
        return entity;;
    }
}