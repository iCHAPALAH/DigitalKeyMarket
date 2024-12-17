using DigitalKeyMarket.Service.IoC;
using DigitalKeyMarket.Service.Settings;

namespace DigitalKeyMarket.Service.DI;

public static class ApplicationConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder, DigitalKeyMarketSettings settings)
    {
        SerilogConfigurator.ConfigureServices(builder);
        SwaggerConfigurator.ConfigureServices(builder.Services);
        DbContextConfigurator.ConfigureServices(builder.Services, settings);
        MapperConfigurator.ConfigureServices(builder.Services);
        ServicesConfigurator.ConfigureServices(builder.Services, settings);
        AuthorizationConfigurator.ConfigureServices(builder.Services, settings);

        builder.Services.AddControllers();
    }

    public static async void ConfigureApplication(WebApplication app, DigitalKeyMarketSettings settings)
    {
        SerilogConfigurator.ConfigureApplication(app);
        SwaggerConfigurator.ConfigureApplication(app);
        DbContextConfigurator.ConfigureApplication(app);
        AuthorizationConfigurator.ConfigureApplication(app);
        await RepositoryInitializer.ConfigureApplication(app, settings);

        app.MapControllers();
    }
}