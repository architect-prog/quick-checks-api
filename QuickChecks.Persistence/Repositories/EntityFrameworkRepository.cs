using Microsoft.EntityFrameworkCore;
using QuickChecks.Kernel.Interfaces;
using QuickChecks.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickChecks.Persistence.Repositories;

public class EntityFrameworkRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext dbContext;

    private DbSet<T> EntitiesSet => dbContext.Set<T>();

    public EntityFrameworkRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await EntitiesSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddRange(IEnumerable<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        await EntitiesSet.AddRangeAsync(entities);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        EntitiesSet.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateRange(IEnumerable<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }

        EntitiesSet.UpdateRange(entities);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        EntitiesSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public Task<int> Count(ISpecification<T> specification)
    {
        if (specification == null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        var entities = specification.AddPredicates(EntitiesSet);
        return entities.CountAsync();
    }

    public Task<bool> Exists(ISpecification<T> specification)
    {
        if (specification == null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        var entities = specification.AddPredicates(EntitiesSet);
        return entities.AnyAsync();
    }

    public async ValueTask<T> GetById(object id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        var result = await EntitiesSet.FindAsync(id);
        return result;
    }

    public Task<T> Get(ISpecification<T> specification)
    {
        if (specification == null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        var result = EntitiesSet.ApplySpecification(specification);
        return result.FirstOrDefaultAsync();
    }

    public async Task<T[]> List(ISpecification<T> specification, int? skip = null, int? take = null)
    {
        if (specification == null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        var entities = EntitiesSet.ApplySpecification(specification);

        if (skip.HasValue)
        {
            entities = entities.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            entities = entities.Take(take.Value);
        }

        var result = await entities.ToArrayAsync();
        return result;
    }
}