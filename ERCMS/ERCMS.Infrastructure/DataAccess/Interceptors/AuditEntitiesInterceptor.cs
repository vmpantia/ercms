using ERCMS.Domain.Extensions;
using ERCMS.Domain.Interfaces.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ERCMS.Infrastructure.DataAccess.Interceptors;

public class AuditEntitiesInterceptor(IHttpContextAccessor httpContextAccessor) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var dbContext = eventData.Context;
        if (dbContext is not null) AuditEntities(dbContext);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var dbContext = eventData.Context;
        if (dbContext is not null) AuditEntities(dbContext);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void AuditEntities(DbContext context)
    {
        var requestor = httpContextAccessor.HttpContext?.User.GetEmail()!;
        var entries = context.ChangeTracker.Entries<IEntity>();

        Parallel.ForEach(entries, entry =>
        {
            var entity = entry.Entity;
            switch (entry.State)
            {
                case EntityState.Added when entity is ICreatableEntity creatableEntity:
                    creatableEntity.CreatedAtUc = DateTimeOffset.UtcNow;
                    creatableEntity.CreatedBy = requestor;
                    break;
                case EntityState.Modified when entity is IEditableEntity editableEntity:
                    editableEntity.ModifiedAtUtc = DateTimeOffset.UtcNow;
                    editableEntity.ModifiedBy = requestor;
                    break;
                case EntityState.Deleted when entity is IDeletableEntity deletableEntity:
                    entry.State = EntityState.Modified;
                    deletableEntity.DeletedAtUtc = DateTimeOffset.UtcNow;
                    deletableEntity.DeletedBy = requestor;
                    break;
            }
        });
    }
}