using System.Linq.Expressions;
using ERCMS.Domain.Interfaces.Entities;
using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ERCMS.Infrastructure.DataAccess.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
{
    private readonly ErcmsDbContext _context;
    private readonly DbSet<TEntity> _table;

    protected BaseRepository(ErcmsDbContext context)
    {
        _context = context;
        _table = context.Set<TEntity>();
    }
    
    public IQueryable<TEntity> GetAll()
    {
        return _table.AsNoTracking();
    }

    public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression)
    {
        return _table.AsNoTracking().Where(expression);
    }

    public async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _table.AsNoTracking().SingleOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<TEntity?> GetOneAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _table.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await _table.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return result.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = _table.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return result.Entity;
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _table.Remove(entity); 
        await _context.SaveChangesAsync(cancellationToken);
    }
}