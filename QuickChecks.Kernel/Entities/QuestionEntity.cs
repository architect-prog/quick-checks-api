using QuickChecks.Kernel.Entities.Enum;
using System.Collections.Generic;

namespace QuickChecks.Kernel.Entities;

public class QuestionEntity
{
    public int Id { get; set; }
    public int OrderIndex { get; set; }
    public bool IsRequired { get; set; }
    public string Content { get; set; }
    public QuestionType Type { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; }
    public IEnumerable<QuestionOptionEntity> Options { get; set; }
} 