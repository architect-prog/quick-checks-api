using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using QuickChecks.Kernel.Interfaces;
using System.Threading.Tasks;

namespace QuickChecks.Persistence.Infrastructure;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly IDbContextTransaction transaction;

    public UnitOfWork(DbContext applicationDatabaseContext)
    {
        transaction = applicationDatabaseContext.Database.BeginTransaction();
    }

    public async Task Commit()
    {
        await transaction.CommitAsync();
    }

    public async Task Rollback()
    {
        await transaction.RollbackAsync();
    }

    public void Dispose()
    {
        transaction.Dispose();
    }
}