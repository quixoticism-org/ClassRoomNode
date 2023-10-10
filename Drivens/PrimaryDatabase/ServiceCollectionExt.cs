using Application.Drivens.PrimaryDatabase;
using Database.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database;

public static class ServiceCollectionExt
{
    public static void AddPrimaryDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Configurations

        services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));

        #endregion

        #region DbConfiguration

        var dbSetting = configuration.GetRequiredSection(nameof(DatabaseSettings)).Get<DatabaseSettings>()!;

        services.AddDbContext<PrimaryDbContext>(cfg => cfg.UseNpgsql(dbSetting.ConnectionStr));

        services.AddScoped<IPrimaryDbContext>(sp => sp.GetRequiredService<PrimaryDbContext>());

        #endregion
    }
}