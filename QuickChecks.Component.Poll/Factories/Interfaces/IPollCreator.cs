using QuickChecks.Component.Poll.Dto.Requests;
using QuickChecks.Kernel.Entities;

namespace QuickChecks.Component.Poll.Factories.Interfaces;

public interface IPollCreator
{
    PollEntity CreatePoll(PollCreateRequest request);
}