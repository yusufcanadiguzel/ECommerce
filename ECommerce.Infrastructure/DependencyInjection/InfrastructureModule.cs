using Autofac;
using ECommerce.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Infrastructure.DependencyInjection;

public class InfrastructureModule : Module
{
    private readonly IConfiguration _configuration;

    public InfrastructureModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        // DbContext Registration
        builder.Register(x =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<ECommerceDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ECommerceDbContext(optionsBuilder.Options);
        })
        .AsSelf()
        .InstancePerLifetimeScope();

        base.Load(builder);
    }
}