namespace QuickChecks.Kernel.Interfaces;

public interface IUnitOfWorkFactory
{
    IUnitOfWork BeginTransaction();
}