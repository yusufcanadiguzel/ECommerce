using ECommerce.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
    }

    public static void ConfigureServiceRegistrations(this IServiceCollection services)
    {
        
    }
}
