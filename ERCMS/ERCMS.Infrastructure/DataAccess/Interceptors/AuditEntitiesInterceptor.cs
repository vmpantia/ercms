using ERCMS.Domain.Extensions;
using ERCMS.Domain.Interfaces.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ERCMS.Infrastructure.DataAccess.Interceptors;

public sealed class AuditEntitiesInterceptor(IHttpContextAccessor httpContextAccessor) : SaveChangesInterceptor
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
                case EntityState.Added:
                    entity.CreatedAtUc = DateTimeOffset.UtcNow;
                    entity.CreatedBy = requestor;
                    break;
                case EntityState.Modified:
                    entity.ModifiedAtUtc = DateTimeOffset.UtcNow;
                    entity.ModifiedBy = requestor;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    MarkUnchangedForOwnedEntries(entry);
                    entity.DeletedAtUtc = DateTimeOffset.UtcNow;
                    entity.DeletedBy = requestor;
                    break;
            }
        });
    }

    private void MarkUnchangedForOwnedEntries(EntityEntry<IEntity> entry) =>
        Parallel.ForEach(entry.References, reference =>
        {
            if (reference.TargetEntry?.Metadata.IsOwned() == true)
                reference.TargetEntry.State = EntityState.Unchanged;
        });
}