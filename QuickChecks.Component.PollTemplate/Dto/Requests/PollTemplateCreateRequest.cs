using QuickChecks.Component.PollTemplate.Dto.Requests.InnerDto;
using System.Collections.Generic;

namespace QuickChecks.Component.PollTemplate.Dto.Requests;

public class PollTemplateCreateRequest
{
    public string Title { get; set; }
    public IEnumerable<CategoryRequestDto> Categories { get; set; }
}