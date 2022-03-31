using QuickChecks.Component.PollTemplate.Dto.Requests.InnerDto;
using QuickChecks.Component.PollTemplate.Dto.Responses.InnerDto;
using QuickChecks.Component.PollTemplate.Mappers.Interfaces;
using QuickChecks.ContentProcessing.Dto.InnerDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickChecks.Component.PollTemplate.Mappers;

public class ParsedQuestionMapper : IParsedQuestionMapper
{
    private readonly IParsedQuestionOptionMapper parsedQuestionOptionMapper;

    public ParsedQuestionMapper(IParsedQuestionOptionMapper parsedQuestionOptionMapper)
    {
        this.parsedQuestionOptionMapper = parsedQuestionOptionMapper;
    }

    public QuestionResponseDto Map(ParsedQuestionDto source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var options = parsedQuestionOptionMapper.MapCollection(source.Options);
        var result = new QuestionResponseDto
        {
            TypeId = source.TypeId,
            Content = source.Content,
            IsRequired = source.IsRequired,
            Options = options
        };

        return result;
    }

    public IEnumerable<QuestionResponseDto> MapCollection(IEnumerable<ParsedQuestionDto> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }

    public ParsedQuestionDto Map(QuestionRequestDto source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var options = parsedQuestionOptionMapper.MapCollection(source.Options);
        var result = new ParsedQuestionDto
        {
            TypeId = source.TypeId,
            Content = source.Content,
            IsRequired = source.IsRequired,
            Options = options
        };

        return result;
    }

    public IEnumerable<ParsedQuestionDto> MapCollection(IEnumerable<QuestionRequestDto> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }
}