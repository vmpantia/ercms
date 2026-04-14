using ERCMS.Domain.Enums;

namespace ERCMS.Application.Features.Users;

public sealed class UserDto
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public CommonStatus Status { get; set; }
    public DateTimeOffset LastModifiedAtUtc { get; set; }
    public required string LastModifiedBy { get; set; }
}