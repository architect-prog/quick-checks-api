using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickChecks.Kernel.Entities;

namespace QuickChecks.Persistence.EntityTypeConfigurations;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder
            .Property(x => x.Name)
            .HasMaxLength(256);

        builder
            .HasMany(x => x.Questions)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}