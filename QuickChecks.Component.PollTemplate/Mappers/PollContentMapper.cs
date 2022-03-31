using QuickChecks.Component.PollTemplate.Dto.Requests;
using QuickChecks.Component.PollTemplate.Mappers.Interfaces;
using QuickChecks.ContentProcessing.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickChecks.Component.PollTemplate.Mappers;

public class PollContentMapper : IPollContentMapper
{
    private readonly IParsedCategoryMapper parsedCategoryMapper;

    public PollContentMapper(IParsedCategoryMapper parsedCategoryMapper)
    {
        this.parsedCategoryMapper = parsedCategoryMapper;
    }

    public PollContentDto Map(PollTemplateCreateRequest source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var categories = parsedCategoryMapper.MapCollection(source.Categories);
        var result = new PollContentDto
        {
            Categories = categories
        };

        return result;
    }

    public IEnumerable<PollContentDto> MapCollection(IEnumerable<PollTemplateCreateRequest> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }

    public PollContentDto Map(PollTemplateUpdateRequest source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var categories = parsedCategoryMapper.MapCollection(source.Categories);
        var result = new PollContentDto
        {
            Categories = categories
        };

        return result;
    }

    public IEnumerable<PollContentDto> MapCollection(IEnumerable<PollTemplateUpdateRequest> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }
}