using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickChecks.Kernel.Interfaces;

public interface IRepository<T> where T : class
{
    Task Add(T entity);
    Task AddRange(IEnumerable<T> entities);
    Task Update(T entity);
    Task UpdateRange(IEnumerable<T> entities);
    Task Delete(T entity);
    Task<int> Count(ISpecification<T> specification);
    Task<bool> Exists(ISpecification<T> specification);
    ValueTask<T> GetById(object id);
    Task<T> Get(ISpecification<T> specification);
    Task<T[]> List(ISpecification<T> specification, int? skip = null, int? take = null);
}