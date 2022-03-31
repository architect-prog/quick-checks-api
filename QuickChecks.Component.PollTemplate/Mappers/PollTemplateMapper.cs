using QuickChecks.Component.PollTemplate.Dto.Responses;
using QuickChecks.Component.PollTemplate.Mappers.Interfaces;
using QuickChecks.Kernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickChecks.Component.PollTemplate.Mappers;

public class PollTemplateMapper : IPollTemplateMapper
{
    public PollTemplateResponse Map(PollTemplateEntity source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = new PollTemplateResponse
        {
            Title = source.Title,
            CreatedDate = source.CreatedDate,
            UpdatedDate = source.UpdatedDate
        };

        return result;
    }

    public IEnumerable<PollTemplateResponse> MapCollection(IEnumerable<PollTemplateEntity> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = source.Select(x => Map(x)).ToArray();
        return result;
    }
}