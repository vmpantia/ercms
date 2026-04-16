using ERCMS.Domain.Enums;
using ERCMS.Domain.Models;

namespace ERCMS.Application.Features.Students;

public class SaveStudentDto
{
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public string? TelephoneNumber { get; set; }
    public required string EmailAddress { get; set; }
    public Address Address { get; set; } = new();
}