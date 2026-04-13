using ERCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERCMS.Infrastructure.DataAccess.Contexts.Configs;

public sealed class ContactConfig : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.ReferenceId).IsUnique();
    }
}