using Autofac;
using ECommerce.Application.Common.Interfaces;

namespace ECommerce.Application.DependencyInjection;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        // Command Handler Registration
        builder.RegisterAssemblyTypes(assembly)
            .AsClosedTypesOf(typeof(ICommandHandler<>))
            .InstancePerLifetimeScope();

        // Query Handler Registration
        builder.RegisterAssemblyTypes(assembly)
            .AsClosedTypesOf(typeof(IQueryHandler<,>))
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}