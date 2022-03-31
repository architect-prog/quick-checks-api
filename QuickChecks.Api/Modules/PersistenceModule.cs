using Autofac;
using Microsoft.EntityFrameworkCore;
using QuickChecks.Kernel.Interfaces;
using QuickChecks.Persistence;
using QuickChecks.Persistence.Infrastructure;
using QuickChecks.Persistence.Infrastructure.Interface;
using QuickChecks.Persistence.Repositories;

namespace QuickChecks.Api.Modules;

public class PersistenceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EntityFrameworkRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
        builder.RegisterType<ApplicationDatabaseContext>().As<DbContext>().InstancePerLifetimeScope();
        builder.RegisterType<DatabaseMigrationApplier>().As<IDatabaseMigrationApplier>().InstancePerLifetimeScope();
    }
}