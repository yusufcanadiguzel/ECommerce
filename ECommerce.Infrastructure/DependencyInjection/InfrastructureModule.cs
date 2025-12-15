using Autofac;

namespace ECommerce.Infrastructure.DependencyInjection.DependencyInjection;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        // Command Handlers
        builder.RegisterAssemblyTypes(assembly)
            .Where(x => x.Name.EndsWith("CommandHandler"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

        // Query Handlers
        builder.RegisterAssemblyTypes(assembly)
            .Where(x => x.Name.EndsWith("QueryHandler"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}