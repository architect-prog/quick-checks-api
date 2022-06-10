using ArchitectProg.FunctionalExtensions.Interfaces;
using QuickChecks.Component.PollTemplate.Factories.Interfaces;
using QuickChecks.Kernel.Entities;
using System;

namespace QuickChecks.Component.PollTemplate.Factories;

public class PollTemplateCloneFactory : IPollTemplateCloneFactory
{
    private readonly IDateTimeProvider dateTimeProvider;

    public PollTemplateCloneFactory(IDateTimeProvider dateTimeProvider)
    {
        this.dateTimeProvider = dateTimeProvider;
    }

    public PollTemplateEntity Clone(PollTemplateEntity source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var currentTime = dateTimeProvider.GetUtcNow();
        var result = new PollTemplateEntity
        {
            Title = source.Title,
            Content = source.Content,
            CreatedDate = currentTime,
            UpdatedDate = currentTime
        };

        return result;
    }
}