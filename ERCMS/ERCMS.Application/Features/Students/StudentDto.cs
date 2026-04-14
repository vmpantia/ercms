using ERCMS.Domain.Enums;
using ERCMS.Domain.Models;

namespace ERCMS.Application.Features.Students;

public class StudentDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string? TelephoneNumber { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public Address Address { get; set; } = new();
    public CommonStatus Status { get; set; }
    public DateTimeOffset LastModifiedAtUtc { get; set; }
    public required string LastModifiedBy { get; set; }
}