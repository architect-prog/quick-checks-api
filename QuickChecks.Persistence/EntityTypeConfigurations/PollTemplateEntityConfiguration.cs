using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickChecks.Kernel.Entities;

namespace QuickChecks.Persistence.EntityTypeConfigurations;

public class PollTemplateEntityConfiguration : IEntityTypeConfiguration<PollTemplateEntity>
{
    public void Configure(EntityTypeBuilder<PollTemplateEntity> builder)
    {
        builder
            .Property(x => x.Title)
            .HasMaxLength(64);
    }
}