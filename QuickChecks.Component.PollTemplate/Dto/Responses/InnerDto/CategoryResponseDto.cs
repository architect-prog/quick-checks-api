using System.Collections.Generic;

namespace QuickChecks.Component.PollTemplate.Dto.Responses.InnerDto;

public class CategoryResponseDto
{
    public string Name { get; set; }
    public IEnumerable<QuestionResponseDto> Questions { get; set; }
}