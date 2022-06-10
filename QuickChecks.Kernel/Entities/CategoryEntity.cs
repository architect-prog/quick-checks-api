using ArchitectProg.Kernel.Extensions.Abstractions;
using System.Collections.Generic;

namespace QuickChecks.Kernel.Entities;

public class CategoryEntity : Entity<int>
{
    public override int Id { get; set; }
    public string Name { get; set; }

    public int PollId { get; set; }
    public PollEntity Poll { get; set; }
    public IEnumerable<QuestionEntity> Questions { get; set; }
}