using QuickChecks.Kernel.Entities;
using System;
using System.Linq;

namespace QuickChecks.Kernel.Specifications.PollTemplate;

public class PollTemplateById : Specification<PollTemplateEntity>
{
    private readonly int pollTemplateId;

    public PollTemplateById(int pollTemplateId)
    {
        this.pollTemplateId = pollTemplateId;
    }

    public override IQueryable<PollTemplateEntity> AddPredicates(IQueryable<PollTemplateEntity> query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var result = query.Where(x => x.Id == pollTemplateId);
        return result;
    }
}