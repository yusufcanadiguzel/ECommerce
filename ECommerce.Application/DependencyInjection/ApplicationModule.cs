using Autofac;

namespace ECommerce.Application.DependencyInjection;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        // Command and Query Handler Registrations
        builder.RegisterAssemblyTypes(assembly)
            .Where(x => x.Name.EndsWith("CommandHandler") 
                     || x.Name.EndsWith("QueryHandler"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}