namespace DigitalKeyMarket.Service.Settings;

public class DigitalKeyMarketSettings
{
    public string DigitalKeyMarketDbContextConnectionString { get; set; }
    public string IdentityServerUri { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string ApiName { get; set; }
    public (string Username, string Password) MasterAdminData { get; set; }
}