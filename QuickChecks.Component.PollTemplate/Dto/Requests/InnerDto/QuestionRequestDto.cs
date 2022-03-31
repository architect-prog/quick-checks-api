using System.Collections.Generic;

namespace QuickChecks.Component.PollTemplate.Dto.Requests.InnerDto;

public class QuestionRequestDto
{
    public int TypeId { get; set; }
    public bool IsRequired { get; set; }
    public string Content { get; set; }
    public IEnumerable<QuestionOptionRequestDto> Options { get; set; }
}