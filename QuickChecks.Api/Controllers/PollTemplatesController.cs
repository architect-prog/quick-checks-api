using DotNet.WebApi.Extensions.Extensions;
using DotNet.WebApi.Extensions.Filters;
using DotNet.WebApi.Extensions.Responses;
using Microsoft.AspNetCore.Mvc;
using QuickChecks.Component.PollTemplate.Dto.Requests;
using QuickChecks.Component.PollTemplate.Dto.Responses;
using QuickChecks.Component.PollTemplate.Services.Interfaces;
using System.Threading.Tasks;

namespace QuickChecks.Api.Controllers;

[Route("api/polls/templates")]
[ApiController]
public class PollTemplatesController : ControllerBase
{
    private readonly IPollTemplateService pollTemplateService;

    public PollTemplatesController(IPollTemplateService pollTemplateService)
    {
        this.pollTemplateService = pollTemplateService;
    }

    [ProducesBadRequest]
    [ProducesCreated(typeof(PollTemplateDetailsResponse))]
    [HttpPost]
    public async Task<IActionResult> Create(PollTemplateCreateRequest request)
    {
        var result = await pollTemplateService.CreatePollTemplate(request);
        return CreatedAtAction(nameof(Get), new { Id = result });
    }

    [ProducesBadRequest]
    [ProducesCreated(typeof(PollTemplateDetailsResponse))]
    [HttpPost("copy/{id:int}")]
    public async Task<IActionResult> Copy(int id)
    {
        var result = await pollTemplateService.CreatePollTemplateCopy(id);
        return CreatedAtAction(nameof(Get), new { Id = result });
    }

    [ProducesOk(typeof(CollectionWrapper<PollTemplateResponse>))]
    [HttpGet]
    public async Task<IActionResult> GetAll(int? skip = null, int? take = null)
    {
        var pollTemplates = await pollTemplateService.GetAllPollTemplates(skip, take);
        var totalCount = await pollTemplateService.GetPollCount();

        var result = pollTemplates.WrapCollection(totalCount);
        return Ok(result);
    }

    [ProducesNotFound]
    [ProducesOk(typeof(PollTemplateDetailsResponse))]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var pollTemplate = await pollTemplateService.GetPollTemplate(id);
        return Ok(pollTemplate);
    }

    [ProducesBadRequest]
    [ProducesNoContent]
    [HttpPut]
    public async Task<IActionResult> Update(PollTemplateUpdateRequest request)
    {
        await pollTemplateService.UpdatePollTemplate(request);
        return NoContent();
    }

    [ProducesNoContent]
    [ProducesNotFound]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await pollTemplateService.DeletePollTemplate(id);
        return NoContent();
    }
}