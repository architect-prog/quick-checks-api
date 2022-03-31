using QuickChecks.Component.PollTemplate.Dto.Responses;
using QuickChecks.Component.PollTemplate.Mappers.Interfaces;
using QuickChecks.ContentProcessing.Interfaces;
using QuickChecks.Kernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickChecks.Component.PollTemplate.Mappers;

public class PollTemplateDetailsMapper : IPollTemplateDetailsMapper
{
    private readonly IPollContentSerializer pollContentSerializer;
    private readonly IParsedCategoryMapper parsedCategoryMapper;

    public PollTemplateDetailsMapper(
        IPollContentSerializer pollContentSerializer,
        IParsedCategoryMapper parsedCategoryMapper)
    {
        this.pollContentSerializer = pollContentSerializer;
        this.parsedCategoryMapper = parsedCategoryMapper;
    }

    public PollTemplateDetailsResponse Map(PollTemplateEntity source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var parsedContent = pollContentSerializer.DeserializePollContent(source.Content);
        var categories = parsedCategoryMapper.MapCollection(parsedContent.Categories);

        var result = new PollTemplateDetailsResponse
        {
            Title = source.Title,
            CreatedDate = source.CreatedDate,
            UpdatedDate = source.UpdatedDate,
            Categories = categories
        };

        return result;
    }

    public IEnumerable<PollTemplateDetailsResponse> MapCollection(IEnumerable<PollTemplateEntity> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }
}