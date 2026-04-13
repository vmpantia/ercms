using ERCMS.Domain.Enums;
using ERCMS.Domain.Interfaces.Entities;

namespace ERCMS.Domain.Entities;

public sealed class Contact : IEntity
{
    public Guid Id { get; set; }
    public Guid ReferenceId { get; set; }
    public string Value { get; set; } = string.Empty;
    public ContactType Type { get; set; }
    public CommonStatus Status { get; set; } 
    
    public DateTimeOffset CreatedAtUc { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTimeOffset? ModifiedAtUtc { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? DeletedAtUtc { get; set; }
    public string? DeletedBy { get; set; }
}