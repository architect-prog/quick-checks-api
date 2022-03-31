using QuickChecks.Component.PollTemplate.Dto.Requests;
using QuickChecks.Component.PollTemplate.Dto.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickChecks.Component.PollTemplate.Services.Interfaces;

public interface IPollTemplateService
{
    Task<PollTemplateDetailsResponse> CreatePollTemplate(PollTemplateCreateRequest request);
    Task<PollTemplateDetailsResponse> CreatePollTemplateCopy(int id);
    Task<PollTemplateDetailsResponse> GetPollTemplate(int id);
    Task<IEnumerable<PollTemplateResponse>> GetAllPollTemplates(int? skip = null, int? take = null);
    Task UpdatePollTemplate(PollTemplateUpdateRequest request);
    Task DeletePollTemplate(int id);
    Task<int> GetPollCount();
}