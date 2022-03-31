using QuickChecks.Component.PollTemplate.Dto.Requests.InnerDto;
using QuickChecks.Component.PollTemplate.Dto.Responses.InnerDto;
using QuickChecks.Component.PollTemplate.Mappers.Interfaces;
using QuickChecks.ContentProcessing.Dto.InnerDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickChecks.Component.PollTemplate.Mappers;

public class ParsedQuestionOptionMapper : IParsedQuestionOptionMapper
{
    public QuestionOptionResponseDto Map(ParsedQuestionOptionDto source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = new QuestionOptionResponseDto
        {
            Content = source.Content,
            Score = source.Score
        };

        return result;
    }

    public IEnumerable<QuestionOptionResponseDto> MapCollection(IEnumerable<ParsedQuestionOptionDto> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }

    public ParsedQuestionOptionDto Map(QuestionOptionRequestDto source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = new ParsedQuestionOptionDto
        {
            Content = source.Content,
            Score = source.Score
        };

        return result;
    }

    public IEnumerable<ParsedQuestionOptionDto> MapCollection(IEnumerable<QuestionOptionRequestDto> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }
}