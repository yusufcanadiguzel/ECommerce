using ECommerce.Infrastructure.Common;
using ECommerce.Infrastructure.Persistance.Context;
using ECommerce.Infrastructure.Persistance.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Context Registration
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Unit of Work Registration
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Repository Registration
        services.Scan(scan =>
            scan.FromAssemblyOf<IInfrastructureMarker>()
            .AddClasses(x => x.InNamespaces("Infrastructure.Persistence.Repository"))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}