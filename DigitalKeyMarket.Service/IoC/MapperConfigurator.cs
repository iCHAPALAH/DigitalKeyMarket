using DigitalKeyMarket.BL.Mappers;

namespace DigitalKeyMarket.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<RolesBLProfile>();
        });
    }
}