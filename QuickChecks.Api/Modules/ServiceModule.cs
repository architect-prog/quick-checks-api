using Autofac;
using QuickChecks.Component.PollTemplate.Services;
using QuickChecks.Component.PollTemplate.Services.Interfaces;

namespace QuickChecks.Api.Modules;

public class ServiceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PollTemplateService>().As<IPollTemplateService>().InstancePerLifetimeScope();
    }
}