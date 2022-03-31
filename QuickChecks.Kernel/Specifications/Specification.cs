using QuickChecks.Kernel.Interfaces;
using System;
using System.Linq;

namespace QuickChecks.Kernel.Specifications;

public class Specification<T> : ISpecification<T>
{
    public virtual IQueryable<T> AddEagerFetching(IQueryable<T> query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return query;
    }

    public virtual IQueryable<T> AddPredicates(IQueryable<T> query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return query;
    }

    public virtual IQueryable<T> AddSorting(IQueryable<T> query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return query;
    }
}