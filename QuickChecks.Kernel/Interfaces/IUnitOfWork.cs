using System;
using System.Threading.Tasks;

namespace QuickChecks.Kernel.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task Commit();
    Task Rollback();
}