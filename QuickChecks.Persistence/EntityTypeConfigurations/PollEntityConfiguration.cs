using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickChecks.Kernel.Entities;

namespace QuickChecks.Persistence.EntityTypeConfigurations;

public class PollEntityConfiguration : IEntityTypeConfiguration<PollEntity>
{
    public void Configure(EntityTypeBuilder<PollEntity> builder)
    {
        builder
            .Property(x => x.Title)
            .HasMaxLength(64);

        builder
            .HasOne(x => x.PollTemplate)
            .WithMany(x => x.Polls)
            .HasForeignKey(x => x.PollTemplateId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(x => x.Categories)
            .WithOne(x => x.Poll)
            .HasForeignKey(x => x.PollId);
    }
}