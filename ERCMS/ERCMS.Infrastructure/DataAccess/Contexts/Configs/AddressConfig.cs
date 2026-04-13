using ERCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERCMS.Infrastructure.DataAccess.Contexts.Configs;

public sealed class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasIndex(a => a.ReferenceId).IsUnique();
    }
}