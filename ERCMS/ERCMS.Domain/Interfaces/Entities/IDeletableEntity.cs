namespace ERCMS.Domain.Interfaces.Entities;

public interface IDeletableEntity
{
    DateTimeOffset? DeletedAtUtc { get; set; }
    string? DeletedBy { get; set; }
}