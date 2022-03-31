using QuickChecks.Component.PollTemplate.Dto.Responses.InnerDto;
using System;
using System.Collections.Generic;

namespace QuickChecks.Component.PollTemplate.Dto.Responses;

public class PollTemplateDetailsResponse
{
    public string Title { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    public IEnumerable<CategoryResponseDto> Categories { get; set; }
}