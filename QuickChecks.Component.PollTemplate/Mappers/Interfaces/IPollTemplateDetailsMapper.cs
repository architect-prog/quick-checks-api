using QuickChecks.Component.PollTemplate.Dto.Responses;
using QuickChecks.Kernel.Entities;
using QuickChecks.Kernel.Interfaces;

namespace QuickChecks.Component.PollTemplate.Mappers.Interfaces;

public interface IPollTemplateDetailsMapper : IMapper<PollTemplateEntity, PollTemplateDetailsResponse>
{
}