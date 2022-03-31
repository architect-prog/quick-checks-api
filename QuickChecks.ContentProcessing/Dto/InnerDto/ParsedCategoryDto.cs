using System.Collections.Generic;

namespace QuickChecks.ContentProcessing.Dto.InnerDto;

public class ParsedCategoryDto
{
    public string Name { get; set; }
    public IEnumerable<ParsedQuestionDto> Questions { get; set; }
}