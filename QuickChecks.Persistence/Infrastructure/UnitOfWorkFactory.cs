using Microsoft.Extensions.DependencyInjection;
using QuickChecks.Kernel.Interfaces;
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
        var dbContext = serviceProvider.GetService<ApplicationDatabaseContext>();
        var result = new UnitOfWork(dbContext);
        return result;
    }
}