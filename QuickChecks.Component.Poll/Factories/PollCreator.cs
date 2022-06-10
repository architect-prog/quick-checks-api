using QuickChecks.Component.Poll.Dto.Requests;
using QuickChecks.Component.Poll.Factories.Interfaces;
using QuickChecks.Kernel.Entities;
using QuickChecks.Kernel.Entities.Enum;

namespace QuickChecks.Component.Poll.Factories;

public class PollCreator : IPollCreator
{
    public PollEntity CreatePoll(PollCreateRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var result = new PollEntity()
        {
            Title = request.Title,
            PollTemplateId = request.PollTemplateId,
            Status = PollStatus.Pending,
            IsDeleted = false
        };

        return result;
    }
}