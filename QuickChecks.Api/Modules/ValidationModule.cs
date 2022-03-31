using Autofac;
using QuickChecks.Component.PollTemplate.Services.Interfaces;
using QuickChecks.Component.PollTemplate.Validation;
using QuickChecks.Component.PollTemplate.Validation.ValidationChecks;
using QuickChecks.Component.PollTemplate.Validation.ValidationChecks.Interfaces;

namespace QuickChecks.Api.Modules;

public class ValidationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PollTemplateValidationChecks>().As<IPollTemplateValidationChecks>().InstancePerLifetimeScope();
        builder.RegisterDecorator<PollTemplateValidationDecorator, IPollTemplateService>();
    }
}