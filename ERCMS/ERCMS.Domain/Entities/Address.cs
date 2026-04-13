using ERCMS.Domain.Enums;
using ERCMS.Domain.Interfaces.Entities;

namespace ERCMS.Domain.Entities;

public sealed class Address : IEntity
{
    public Guid Id { get; set; }
    public Guid ReferenceId { get; set; }
    public string AddressLine1 { get; set; } = string.Empty;
    public string AddressLine2 { get; set; } = string.Empty;
    public string Barangay { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int ZipCode { get; set; }
    public AddressType Type { get; set; }
    public CommonStatus Status { get; set; }
    
    public DateTimeOffset CreatedAtUc { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTimeOffset? ModifiedAtUtc { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? DeletedAtUtc { get; set; }
    public string? DeletedBy { get; set; }
}