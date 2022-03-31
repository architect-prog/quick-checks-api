using QuickChecks.Component.PollTemplate.Dto.Requests;
using QuickChecks.ContentProcessing.Dto;
using QuickChecks.Kernel.Interfaces;

namespace QuickChecks.Component.PollTemplate.Mappers.Interfaces;

public interface IPollContentMapper :
    IMapper<PollTemplateCreateRequest, PollContentDto>,
    IMapper<PollTemplateUpdateRequest, PollContentDto>
{
}