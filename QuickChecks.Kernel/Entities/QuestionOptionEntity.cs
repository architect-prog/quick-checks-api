namespace QuickChecks.Kernel.Entities;

public class QuestionOptionEntity
{
    public int Id { get; set; }
    public int OrderIndex { get; set; }
    public string Content { get; set; }
    public int Score { get; set; }

    public int QuestionId { get; set; }
    public QuestionEntity Question { get; set; }
}