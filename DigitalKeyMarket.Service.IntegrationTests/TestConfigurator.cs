using DigitalKeyMarket.Service.Settings;
using Microsoft.Extensions.Configuration;

namespace DigitalKeyMarket.Service.IntegrationTests;

public class TestConfigurator
{
    private static IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
    }

    public static DigitalKeyMarketSettings GetSettings()
    {
        return DigitalKeyMarketSettingsReader.Read(GetConfiguration());
    }
}