namespace DigitalKeyMarket.Service.Settings;

public static class DigitalKeyMarketSettingsReader
{
    public static DigitalKeyMarketSettings Read(IConfiguration configuration)
    {
        return new DigitalKeyMarketSettings
        {
            DigitalKeyMarketDbContextConnectionString = configuration.GetConnectionString("DigitalKeyMarketDbContext"),
            IdentityServerUri = configuration.GetValue<string>("IdentityServer:Uri"),
            ClientId = configuration.GetValue<string>("IdentityServer:ClientId"),
            ClientSecret = configuration.GetValue<string>("IdentityServer:ClientSecret"),
            ApiName = configuration.GetValue<string>("IdentityServer:ApiName"),
            MasterAdminData = new ValueTuple<string, string>(
                configuration.GetValue<string>("IdentityServer:MasterAdminData:UserName"),
                configuration.GetValue<string>("IdentityServer:MasterAdminData:Password"))
        };
    }
}