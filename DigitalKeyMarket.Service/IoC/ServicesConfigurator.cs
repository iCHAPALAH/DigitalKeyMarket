using AutoMapper;
using DigitalKeyMarket.BL.Roles.Manager;
using DigitalKeyMarket.BL.Roles.Provider;
using DigitalKeyMarket.BL.Users.Manager;
using DigitalKeyMarket.BL.Users.Provider;
using DigitalKeyMarket.DataAccess;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DigitalKeyMarket.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<UserEntity>>(x => 
            new Repository<UserEntity>(x.GetRequiredService<IDbContextFactory<DigitalKeyMarketDbContext>>()));
        services.AddScoped<IUsersProvider>(x => 
            new UsersProvider(x.GetRequiredService<IRepository<UserEntity>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IUsersManager>(x =>
            new UsersManager(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<RoleEntity>>(x => 
            new Repository<RoleEntity>(x.GetRequiredService<IDbContextFactory<DigitalKeyMarketDbContext>>()));
        services.AddScoped<IRolesProvider>(x => 
            new RolesProvider(x.GetRequiredService<IRepository<RoleEntity>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IRolesManager>(x =>
            new RolesManager(x.GetRequiredService<IRepository<RoleEntity>>(),
                x.GetRequiredService<IMapper>()));
    }
}