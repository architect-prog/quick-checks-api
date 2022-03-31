using QuickChecks.ContentProcessing.Dto;

namespace QuickChecks.ContentProcessing.Interfaces;

public interface IPollContentSerializer
{
    string SerializePollContent(PollContentDto content);
    PollContentDto DeserializePollContent(string content);
}