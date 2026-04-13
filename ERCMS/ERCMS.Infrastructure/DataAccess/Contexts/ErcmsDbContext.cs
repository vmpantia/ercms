using ERCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERCMS.Infrastructure.DataAccess.Contexts;

public sealed class ErcmsDbContext(DbContextOptions<ErcmsDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<EmailAddress> EmailAddresses => Set<EmailAddress>();
    public DbSet<Address> Addresses => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }
}