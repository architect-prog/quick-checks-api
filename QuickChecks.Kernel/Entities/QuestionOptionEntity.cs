using ArchitectProg.Kernel.Extensions.Abstractions;

namespace QuickChecks.Kernel.Entities;

public class QuestionOptionEntity : Entity<int>
{
    public override int Id { get; set; }
    public int OrderIndex { get; set; }
    public string Content { get; set; }
    public int Score { get; set; }

    public int QuestionId { get; set; }
    public QuestionEntity Question { get; set; }
}