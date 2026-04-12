namespace ERCMS.Domain.Interfaces.Entities;

public interface ICreatableEntity
{
    DateTimeOffset CreatedAtUc { get; set; }
    string CreatedBy { get; set; }
}