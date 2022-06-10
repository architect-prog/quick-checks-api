using ArchitectProg.FunctionalExtensions.Interfaces;
using ArchitectProg.FunctionalExtensions.Services;
using Autofac;
using QuickChecks.ContentProcessing.Interfaces;
using QuickChecks.ContentProcessing.Services;

namespace QuickChecks.Api.Modules;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AssemblyFileReader>().As<IAssemblyFileReader>().InstancePerLifetimeScope();
        builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>().InstancePerLifetimeScope();
        builder.RegisterType<PollContentSerializer>().As<IPollContentSerializer>().InstancePerLifetimeScope();
        builder.RegisterType<SerializerFactory>().As<ISerializerFactory>().InstancePerLifetimeScope();
    }
}