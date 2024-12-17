using DigitalKeyMarket.BL.Mappers;
using DigitalKeyMarket.Service.Mapper;

namespace DigitalKeyMarket.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<AuthBLProfile>();
            config.AddProfile<AuthServiceProfile>();
            
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<UsersServiceProfile>();
            
            config.AddProfile<RolesBLProfile>();
            config.AddProfile<RolesBLProfile>();
        });
    }
}