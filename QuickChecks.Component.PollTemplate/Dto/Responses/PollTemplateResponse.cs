using System;

namespace QuickChecks.Component.PollTemplate.Dto.Responses;

public class PollTemplateResponse
{
    public string Title { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}