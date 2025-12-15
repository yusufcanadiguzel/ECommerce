using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerce.Api.DependencyInjection;
using ECommerce.Api.Extensions;
using ECommerce.Api.Middlewares;
using ECommerce.Application.DependencyInjection.DependencyInjection;
using ECommerce.Infrastructure.DependencyInjection.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApiModule());
        containerBuilder.RegisterModule(new ApplicationModule());
        containerBuilder.RegisterModule(new InfrastructureModule());
    });

// Database Connection
builder.Services.ConfigureDatabaseConnection(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Global Exception Middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
