using ArchitectProg.Kernel.Extensions.Interfaces;
using QuickChecks.Component.PollTemplate.Validation.ValidationChecks.Interfaces;
using QuickChecks.Kernel.Entities;
using QuickChecks.Kernel.Specifications.PollTemplate;
using System.Threading.Tasks;

namespace QuickChecks.Component.PollTemplate.Validation.ValidationChecks;

public class PollTemplateValidationChecks : IPollTemplateValidationChecks
{
    private readonly IRepository<PollTemplateEntity> repository;

    public PollTemplateValidationChecks(IRepository<PollTemplateEntity> repository)
    {
        this.repository = repository;
    }

    public Task<bool> IsPollTemplateExists(int id)
    {
        var specification = new PollTemplateById(id);
        return repository.Exists(specification);
    }
}