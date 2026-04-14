using ERCMS.Domain.Entities;
using ERCMS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ERCMS.Infrastructure.DataAccess.Contexts;

public sealed class ErcmsDbContext(DbContextOptions<ErcmsDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }
}