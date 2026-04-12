namespace ERCMS.Domain.Interfaces.Entities;

public interface IEditableEntity
{
    DateTimeOffset? ModifiedAtUtc { get; set; }
    string? ModifiedBy { get; set; }
}