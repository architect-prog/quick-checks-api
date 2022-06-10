namespace QuickChecks.Component.Poll.Dto.Requests;

public class PollCreateRequest
{
    public string? Title { get; set; }
    public int PollTemplateId { get; set; }
}