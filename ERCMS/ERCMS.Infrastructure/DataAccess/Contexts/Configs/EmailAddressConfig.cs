using ERCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERCMS.Infrastructure.DataAccess.Contexts.Configs;

public sealed class EmailAddressConfig : IEntityTypeConfiguration<EmailAddress>
{
    public void Configure(EntityTypeBuilder<EmailAddress> builder)
    {
        builder.HasKey(ea => ea.Id);
        builder.HasIndex(ea => ea.ReferenceId).IsUnique();
    }
}