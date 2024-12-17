using AutoMapper;
using DigitalKeyMarket.BL.Auth.Provider;
using DigitalKeyMarket.BL.Roles.Provider;
using DigitalKeyMarket.BL.Users.Manager;
using DigitalKeyMarket.BL.Users.Provider;
using DigitalKeyMarket.DataAccess;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;
using DigitalKeyMarket.Service.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitalKeyMarket.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services, DigitalKeyMarketSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<RoleEntity>>(x =>
            new Repository<RoleEntity>(x.GetRequiredService<IDbContextFactory<DigitalKeyMarketDbContext>>()));

        services.AddScoped<IRolesProvider>(x =>
            new RolesProvider(x.GetRequiredService<IRepository<RoleEntity>>(),
                x.GetRequiredService<IMapper>()));

        services.AddScoped<IUsersProvider>(x =>
            new UsersProvider(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IUsersManager>(x =>
            new UsersManager(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IRepository<RoleEntity>>(),
                x.GetRequiredService<IMapper>()));

        services.AddScoped<IAuthProvider>(x => new AuthProvider(
            x.GetRequiredService<SignInManager<UserEntity>>(),
            x.GetRequiredService<UserManager<UserEntity>>(),
            x.GetRequiredService<IHttpClientFactory>(),
            x.GetRequiredService<IMapper>(),
            settings.IdentityServerUri,
            settings.ClientId,
            settings.ClientSecret));
    }
}