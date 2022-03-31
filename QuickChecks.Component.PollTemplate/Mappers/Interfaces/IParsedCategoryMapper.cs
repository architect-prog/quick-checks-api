using QuickChecks.Component.PollTemplate.Dto.Requests.InnerDto;
using QuickChecks.Component.PollTemplate.Dto.Responses.InnerDto;
using QuickChecks.ContentProcessing.Dto.InnerDto;
using QuickChecks.Kernel.Interfaces;

namespace QuickChecks.Component.PollTemplate.Mappers.Interfaces;

public interface IParsedCategoryMapper :
    IMapper<ParsedCategoryDto, CategoryResponseDto>,
    IMapper<CategoryRequestDto, ParsedCategoryDto>
{
}