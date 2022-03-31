using QuickChecks.Component.PollTemplate.Dto.Requests;
using QuickChecks.Kernel.Entities;

namespace QuickChecks.Component.PollTemplate.Factories.Interfaces;

public interface IPollTemplateCreator
{
    PollTemplateEntity CreatePollTemplate(PollTemplateCreateRequest request);
}