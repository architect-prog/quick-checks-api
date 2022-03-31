using QuickChecks.Component.PollTemplate.Dto.Requests;
using QuickChecks.Component.PollTemplate.Dto.Responses;
using QuickChecks.Component.PollTemplate.Services.Interfaces;
using QuickChecks.Component.PollTemplate.Validation.ValidationChecks.Interfaces;
using QuickChecks.Kernel.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickChecks.Component.PollTemplate.Validation;

public class PollTemplateValidationDecorator : IPollTemplateService
{
    private readonly IPollTemplateService pollTemplateService;
    private readonly IPollTemplateValidationChecks pollTemplateValidationChecks;

    public PollTemplateValidationDecorator(
        IPollTemplateService pollTemplateService,
        IPollTemplateValidationChecks pollTemplateValidationChecks)
    {
        this.pollTemplateService = pollTemplateService;
        this.pollTemplateValidationChecks = pollTemplateValidationChecks;
    }

    public Task<PollTemplateDetailsResponse> CreatePollTemplate(PollTemplateCreateRequest request)
    {
        return pollTemplateService.CreatePollTemplate(request);
    }

    public async Task<PollTemplateDetailsResponse> CreatePollTemplateCopy(int id)
    {
        var isExist = await pollTemplateValidationChecks.IsPollTemplateExists(id);
        if (!isExist)
        {
            throw new ResourceNotFoundException("pollTemplate");
        }

        var result = await pollTemplateService.CreatePollTemplateCopy(id);
        return result;
    }

    public async Task<PollTemplateDetailsResponse> GetPollTemplate(int id)
    {
        var isExist = await pollTemplateValidationChecks.IsPollTemplateExists(id);
        if (!isExist)
        {
            throw new ResourceNotFoundException("pollTemplate");
        }

        var result = await pollTemplateService.GetPollTemplate(id);
        return result;
    }

    public Task<IEnumerable<PollTemplateResponse>> GetAllPollTemplates(int? skip = null, int? take = null)
    {
        return pollTemplateService.GetAllPollTemplates(skip, take);
    }

    public async Task UpdatePollTemplate(PollTemplateUpdateRequest request)
    {
        var isExist = await pollTemplateValidationChecks.IsPollTemplateExists(request.Id);
        if (!isExist)
        {
            throw new ResourceNotFoundException("pollTemplate");
        }

        await pollTemplateService.UpdatePollTemplate(request);
    }

    public async Task DeletePollTemplate(int id)
    {
        var isExist = await pollTemplateValidationChecks.IsPollTemplateExists(id);
        if (!isExist)
        {
            throw new ResourceNotFoundException("pollTemplate");
        }

        await pollTemplateService.DeletePollTemplate(id);
    }

    public Task<int> GetPollCount()
    {
        return pollTemplateService.GetPollCount();
    }
}