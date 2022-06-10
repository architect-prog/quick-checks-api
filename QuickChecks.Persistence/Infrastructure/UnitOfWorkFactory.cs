using ArchitectProg.Kernel.Extensions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace QuickChecks.Persistence.Infrastructure;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IServiceProvider serviceProvider;

    public UnitOfWorkFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IUnitOfWork BeginTransaction()
    {
        var dbContext = serviceProvider.GetService<DbContext>();
        var result = new UnitOfWork(dbContext);
        return result;
    }
}