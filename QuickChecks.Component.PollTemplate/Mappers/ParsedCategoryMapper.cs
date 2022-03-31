using QuickChecks.Component.PollTemplate.Dto.Requests.InnerDto;
using QuickChecks.Component.PollTemplate.Dto.Responses.InnerDto;
using QuickChecks.Component.PollTemplate.Mappers.Interfaces;
using QuickChecks.ContentProcessing.Dto.InnerDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickChecks.Component.PollTemplate.Mappers;

public class ParsedCategoryMapper : IParsedCategoryMapper
{
    private readonly IParsedQuestionMapper parsedQuestionMapper;

    public ParsedCategoryMapper(IParsedQuestionMapper parsedQuestionMapper)
    {
        this.parsedQuestionMapper = parsedQuestionMapper;
    }

    public CategoryResponseDto Map(ParsedCategoryDto source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var questions = parsedQuestionMapper.MapCollection(source.Questions);
        var result = new CategoryResponseDto
        {
            Name = source.Name,
            Questions = questions
        };

        return result;
    }

    public IEnumerable<CategoryResponseDto> MapCollection(IEnumerable<ParsedCategoryDto> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }

    public ParsedCategoryDto Map(CategoryRequestDto source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var questions = parsedQuestionMapper.MapCollection(source.Questions);
        var result = new ParsedCategoryDto
        {
            Name = source.Name,
            Questions = questions
        };

        return result;
    }

    public IEnumerable<ParsedCategoryDto> MapCollection(IEnumerable<CategoryRequestDto> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }
}