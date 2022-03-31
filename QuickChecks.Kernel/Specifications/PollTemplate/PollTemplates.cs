using QuickChecks.Kernel.Entities;
using System.Linq;

namespace QuickChecks.Kernel.Specifications.PollTemplate;

public class PollTemplates : Specification<PollTemplateEntity>
{
    public override IQueryable<PollTemplateEntity> AddPredicates(IQueryable<PollTemplateEntity> query)
    {
        return query;
    }
}