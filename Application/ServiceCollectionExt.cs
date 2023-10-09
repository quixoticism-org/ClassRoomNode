using Application.Domain.Services;
using Application.Drivings.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExt
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        #region Services

        services.AddScoped<IOrganizationService, OrganizationService>();

        #endregion
        
        #region UseCases

        services.AddMediatR(cfg 
            => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExt).Assembly));
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationPipeline<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

        #endregion
    }
}