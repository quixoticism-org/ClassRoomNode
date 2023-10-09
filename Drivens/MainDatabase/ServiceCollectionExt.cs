using Application.Drivens.MainDatabase;
using Database.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database;

public static class ServiceCollectionExt
{
    public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Configurations

        services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));

        #endregion

        #region DbConfiguration

        var dbSetting = configuration.GetRequiredSection(nameof(DatabaseSettings)).Get<DatabaseSettings>()!;

        services.AddDbContext<MainDbContext>(cfg => cfg.UseNpgsql(dbSetting.ConnectionStr));

        services.AddScoped<IMainDbContext>(sp => sp.GetRequiredService<MainDbContext>());

        #endregion
    }
}