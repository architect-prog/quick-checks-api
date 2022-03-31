using System.Collections.Generic;

namespace QuickChecks.Component.PollTemplate.Dto.Requests.InnerDto;

public class CategoryRequestDto
{
    public string Name { get; set; }
    public IEnumerable<QuestionRequestDto> Questions { get; set; }
}