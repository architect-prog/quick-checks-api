using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickChecks.Kernel.Entities;

namespace QuickChecks.Persistence.EntityTypeConfigurations;

public class QuestionOptionEntityConfiguration : IEntityTypeConfiguration<QuestionOptionEntity>
{
    public void Configure(EntityTypeBuilder<QuestionOptionEntity> builder)
    {

    }
}