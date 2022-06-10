using Autofac;
using QuickChecks.Component.PollTemplate.Factories;
using QuickChecks.Component.PollTemplate.Factories.Interfaces;

namespace QuickChecks.Api.Modules;

public class FactoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PollTemplateCloneFactory>().As<IPollTemplateCloneFactory>().InstancePerLifetimeScope();
        builder.RegisterType<PollTemplateCreator>().As<IPollTemplateCreator>().InstancePerLifetimeScope();


    }
}