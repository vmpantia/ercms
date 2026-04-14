using ERCMS.Application.Features.Students.CreateStudent;
using ERCMS.Domain.Entities;
using ERCMS.Domain.Enums;
using ERCMS.Domain.Models;

namespace ERCMS.Application.Features.Students;

public static class StudentMappings
{
    public static Student Map(this CreateStudentDto dto)
    {
        var entity = new Student
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Gender = dto.Gender,
            DateOfBirth = dto.DateOfBirth,
            PhoneNumber = dto.PhoneNumber,
            TelephoneNumber = dto.TelephoneNumber,
            EmailAddress = dto.EmailAddress,
            Address = new Address
            {
                Line1 = dto.Address.Line1,
                Line2 = dto.Address.Line2,
                Barangay = dto.Address.Barangay,
                City = dto.Address.City,
                Province = dto.Address.Province,
                Country = dto.Address.Country,
                ZipCode = dto.Address.ZipCode
            },
            Status = CommonStatus.Enabled
        };

        return entity;
    }
    
    public static StudentDto Map(this Student entity)
    {
        var dto = new StudentDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            MiddleName = entity.MiddleName,
            LastName = entity.LastName,
            Gender = entity.Gender,
            DateOfBirth = entity.DateOfBirth,
            PhoneNumber = entity.PhoneNumber,
            TelephoneNumber = entity.TelephoneNumber,
            EmailAddress = entity.EmailAddress,
            Address = new Address
            {
                Line1 = entity.Address.Line1,
                Line2 = entity.Address.Line2,
                Barangay = entity.Address.Barangay,
                City = entity.Address.City,
                Province = entity.Address.Province,
                Country = entity.Address.Country,
                ZipCode = entity.Address.ZipCode,
            },
            Status = entity.Status,
            LastModifiedAtUtc = entity.ModifiedAtUtc ?? entity.CreatedAtUc,
            LastModifiedBy = entity.ModifiedBy ?? entity.CreatedBy
        };

        return dto;
    }
}