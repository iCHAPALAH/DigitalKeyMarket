namespace DigitalKeyMarket.Service.Settings;

public static class DigitalKeyMarketSettingsReader
{
    public static DigitalKeyMarketSettings Read(IConfiguration configuration)
    {
        return new DigitalKeyMarketSettings
        {
            DigitalKeyMarketDbContextConnectionString = configuration.GetConnectionString("DigitalKeyMarketDbContext")
        };
    }
}