using System.Collections.Generic;

namespace QuickChecks.Kernel.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int PollId { get; set; }
    public PollEntity Poll { get; set; }
    public IEnumerable<QuestionEntity> Questions { get; set; }
}