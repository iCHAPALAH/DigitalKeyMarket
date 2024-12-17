using DigitalKeyMarket.DataAccess;
using DigitalKeyMarket.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace DigitalKeyMarket.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureServices(IServiceCollection services, DigitalKeyMarketSettings settings)
    {
        var connectionString = settings.DigitalKeyMarketDbContextConnectionString;
        services.AddDbContextFactory<DigitalKeyMarketDbContext>(
            options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DigitalKeyMarketDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}