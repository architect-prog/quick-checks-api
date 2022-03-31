using Autofac;
using QuickChecks.Component.PollTemplate.Mappers;
using QuickChecks.Component.PollTemplate.Mappers.Interfaces;

namespace QuickChecks.Api.Modules;

public class MappingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ParsedCategoryMapper>().As<IParsedCategoryMapper>().InstancePerLifetimeScope();
        builder.RegisterType<ParsedQuestionMapper>().As<IParsedQuestionMapper>().InstancePerLifetimeScope();
        builder.RegisterType<ParsedQuestionOptionMapper>().As<IParsedQuestionOptionMapper>().InstancePerLifetimeScope();
        builder.RegisterType<PollContentMapper>().As<IPollContentMapper>().InstancePerLifetimeScope();
        builder.RegisterType<PollTemplateDetailsMapper>().As<IPollTemplateDetailsMapper>().InstancePerLifetimeScope();
        builder.RegisterType<PollTemplateMapper>().As<IPollTemplateMapper>().InstancePerLifetimeScope();
    }
}