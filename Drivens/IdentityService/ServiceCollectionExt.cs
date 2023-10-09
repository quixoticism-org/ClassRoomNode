using Application.Drivens.IdentityService.Services;
using IdentityService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService;

public static class ServiceCollectionExt
{
    public static void AddIdentityServiceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAuthService, AuthService>();
        services.AddSingleton<IUserStorage, UserStorage>();
    }
}