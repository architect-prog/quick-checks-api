using ArchitectProg.Kernel.Extensions.Interfaces;
using QuickChecks.Component.PollTemplate.Dto.Requests.InnerDto;
using QuickChecks.Component.PollTemplate.Dto.Responses.InnerDto;
using QuickChecks.ContentProcessing.Dto.InnerDto;

namespace QuickChecks.Component.PollTemplate.Mappers.Interfaces;

public interface IParsedQuestionMapper :
    IMapper<ParsedQuestionDto, QuestionResponseDto>,
    IMapper<QuestionRequestDto, ParsedQuestionDto>
{
}