using ArchitectProg.Kernel.Extensions.Interfaces;
using QuickChecks.Component.PollTemplate.Dto.Responses;
using QuickChecks.Kernel.Entities;

namespace QuickChecks.Component.PollTemplate.Mappers.Interfaces;

public interface IPollTemplateDetailsMapper : IMapper<PollTemplateEntity, PollTemplateDetailsResponse>
{
}