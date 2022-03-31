using DotNet.FunctionalExtensions.Interfaces;
using QuickChecks.Component.PollTemplate.Dto.Requests;
using QuickChecks.Component.PollTemplate.Dto.Responses;
using QuickChecks.Component.PollTemplate.Factories.Interfaces;
using QuickChecks.Component.PollTemplate.Mappers.Interfaces;
using QuickChecks.Component.PollTemplate.Services.Interfaces;
using QuickChecks.ContentProcessing.Interfaces;
using QuickChecks.Kernel.Entities;
using QuickChecks.Kernel.Interfaces;
using QuickChecks.Kernel.Specifications.PollTemplate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickChecks.Component.PollTemplate.Services;

public class PollTemplateService : IPollTemplateService
{
    private readonly IPollTemplateCreator pollTemplateCreator;
    private readonly IUnitOfWorkFactory unitOfWorkFactory;
    private readonly IPollTemplateMapper pollTemplateMapper;
    private readonly IPollTemplateDetailsMapper pollTemplateDetailsMapper;
    private readonly IPollTemplateCloneFactory pollTemplateCloneFactory;
    private readonly IRepository<PollTemplateEntity> repository;
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly IPollContentSerializer pollContentSerializer;
    private readonly IPollContentMapper pollContentMapper;

    public PollTemplateService(
        IPollTemplateCreator pollTemplateCreator,
        IUnitOfWorkFactory unitOfWorkFactory,
        IPollTemplateMapper pollTemplateMapper,
        IPollTemplateDetailsMapper pollTemplateDetailsMapper,
        IPollTemplateCloneFactory pollTemplateCloneFactory,
        IRepository<PollTemplateEntity> repository,
        IDateTimeProvider dateTimeProvider,
        IPollContentSerializer pollContentSerializer,
        IPollContentMapper pollContentMapper)
    {
        this.repository = repository;
        this.pollTemplateCreator = pollTemplateCreator;
        this.unitOfWorkFactory = unitOfWorkFactory;
        this.pollTemplateMapper = pollTemplateMapper;
        this.pollTemplateDetailsMapper = pollTemplateDetailsMapper;
        this.pollTemplateCloneFactory = pollTemplateCloneFactory;
        this.dateTimeProvider = dateTimeProvider;
        this.pollContentSerializer = pollContentSerializer;
        this.pollContentMapper = pollContentMapper;
    }

    public async Task<PollTemplateDetailsResponse> CreatePollTemplate(PollTemplateCreateRequest request)
    {
        var poll = pollTemplateCreator.CreatePollTemplate(request);

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await repository.Add(poll);
            await transaction.Commit();
        }

        var result = pollTemplateDetailsMapper.Map(poll);
        return result;
    }

    public async Task<PollTemplateDetailsResponse> CreatePollTemplateCopy(int id)
    {
        var poll = await repository.GetById(id);

        var pollClone = pollTemplateCloneFactory.Clone(poll);
        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await repository.Add(pollClone);
            await transaction.Commit();
        }

        var result = pollTemplateDetailsMapper.Map(poll);
        return result;
    }

    public async Task<PollTemplateDetailsResponse> GetPollTemplate(int id)
    {
        var specification = new PollTemplateById(id);
        var poll = await repository.Get(specification);

        var result = pollTemplateDetailsMapper.Map(poll);
        return result;
    }

    public async Task<IEnumerable<PollTemplateResponse>> GetAllPollTemplates(int? skip = null, int? take = null)
    {
        var specification = new PollTemplates();
        var polls = await repository.List(specification, skip, take);

        var result = pollTemplateMapper.MapCollection(polls);
        return result;
    }

    public async Task UpdatePollTemplate(PollTemplateUpdateRequest request)
    {
        var specification = new PollTemplateById(request.Id);
        var updatedPoll = await repository.Get(specification);

        var pollContent = pollContentMapper.Map(request);
        var updatedContent = pollContentSerializer.SerializePollContent(pollContent);

        updatedPoll.Title = request.Title;
        updatedPoll.Content = updatedContent;
        updatedPoll.UpdatedDate = dateTimeProvider.GetUtcNow();

        using (var transaction = unitOfWorkFactory.BeginTransaction())
        {
            await repository.Update(updatedPoll);
            await transaction.Commit();
        }
    }

    public async Task DeletePollTemplate(int id)
    {
        var specification = new PollTemplateById(id);
        var poll = await repository.Get(specification);

        await repository.Delete(poll);
    }

    public Task<int> GetPollCount()
    {
        var specification = new PollTemplates();
        var result = repository.Count(specification);

        return result;
    }
}