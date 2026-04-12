namespace ERCMS.Domain.Interfaces.Entities;

public interface IEntity : ICreatableEntity, IEditableEntity, IDeletableEntity
{
    Guid Id { get; set; }
}