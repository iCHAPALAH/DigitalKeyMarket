using DigitalKeyMarket.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DigitalKeyMarket.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        var connectionString = configuration.GetConnectionString("DigitalKeyMarketDbContext");

        builder.Services.AddDbContextFactory<DigitalKeyMarketDbContext>(
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