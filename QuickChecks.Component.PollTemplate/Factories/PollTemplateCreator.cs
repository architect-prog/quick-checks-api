using DotNet.FunctionalExtensions.Interfaces;
using QuickChecks.Component.PollTemplate.Dto.Requests;
using QuickChecks.Component.PollTemplate.Factories.Interfaces;
using QuickChecks.Component.PollTemplate.Mappers.Interfaces;
using QuickChecks.ContentProcessing.Interfaces;
using QuickChecks.Kernel.Entities;
using System;

namespace QuickChecks.Component.PollTemplate.Factories;

public class PollTemplateCreator : IPollTemplateCreator
{
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly IPollContentSerializer pollContentSerializer;
    private readonly IPollContentMapper pollContentMapper;

    public PollTemplateCreator(
        IDateTimeProvider dateTimeProvider,
        IPollContentSerializer pollContentSerializer,
        IPollContentMapper pollContentMapper)
    {
        this.dateTimeProvider = dateTimeProvider;
        this.pollContentSerializer = pollContentSerializer;
        this.pollContentMapper = pollContentMapper;
    }

    public PollTemplateEntity CreatePollTemplate(PollTemplateCreateRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var pollContent = pollContentMapper.Map(request);
        var content = pollContentSerializer.SerializePollContent(pollContent);

        var currentTime = dateTimeProvider.GetUtcNow();
        var result = new PollTemplateEntity
        {
            Title = request.Title,
            CreatedDate = currentTime,
            UpdatedDate = currentTime,
            Content = content
        };

        return result;
    }
}