using ArchitectProg.Kernel.Extensions.Interfaces;
using QuickChecks.Component.PollTemplate.Dto.Requests;
using QuickChecks.ContentProcessing.Dto;

namespace QuickChecks.Component.PollTemplate.Mappers.Interfaces;

public interface IPollContentMapper :
    IMapper<PollTemplateCreateRequest, PollContentDto>,
    IMapper<PollTemplateUpdateRequest, PollContentDto>
{
}