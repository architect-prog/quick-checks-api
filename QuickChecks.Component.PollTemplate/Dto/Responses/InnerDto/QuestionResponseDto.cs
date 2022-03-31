using System.Collections.Generic;

namespace QuickChecks.Component.PollTemplate.Dto.Responses.InnerDto;

public class QuestionResponseDto
{
    public int TypeId { get; set; }
    public bool IsRequired { get; set; }
    public string Content { get; set; }
    public IEnumerable<QuestionOptionResponseDto> Options { get; set; }
}