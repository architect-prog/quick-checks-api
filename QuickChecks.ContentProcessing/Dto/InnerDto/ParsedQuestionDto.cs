using System.Collections.Generic;

namespace QuickChecks.ContentProcessing.Dto.InnerDto;

public class ParsedQuestionDto
{
    public int TypeId { get; set; }
    public bool IsRequired { get; set; }
    public string Content { get; set; }
    public IEnumerable<ParsedQuestionOptionDto> Options { get; set; }
}