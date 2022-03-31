using QuickChecks.Kernel.Entities;

namespace QuickChecks.Component.PollTemplate.Factories.Interfaces;

public interface IPollTemplateCloneFactory
{
    PollTemplateEntity Clone(PollTemplateEntity source);
}