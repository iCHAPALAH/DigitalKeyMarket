using DigitalKeyMarket.BL.Auth.Model;
using DigitalKeyMarket.BL.Auth.Provider;
using DigitalKeyMarket.BL.Users.Manager;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.BL.Users.Provider;
using DigitalKeyMarket.DataAccess;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace DigitalKeyMarket.Service.IoC;

public static class RepositoryInitializer
{
    private static async Task<List<RoleEntity>> InitializeRoles(IDbContextFactory<DigitalKeyMarketDbContext> dbContextFactory)
    {
        var roles = new List<RoleEntity>();

        await using var context = await dbContextFactory.CreateDbContextAsync();

        foreach (var name in new List<string> { "Customer", "Moderator", "Admin", "MasterAdmin" })
        {
            var roleEntity = await context.Roles.FirstOrDefaultAsync(x => x.Name == name);
            
            if (roleEntity != null)
                roles.Add(roleEntity);
            else
            {
                var roleEntry = await context.Roles.AddAsync(new RoleEntity
                {
                    ExternalId = Guid.NewGuid(),
                    CreationTime = DateTime.UtcNow,
                    ModificationTime = DateTime.UtcNow,
                    Name = name
                });
                
                roles.Add(roleEntry.Entity);
            }
        }

        await context.SaveChangesAsync();
        return roles;
    }

    private static async Task<UserModel> CreateGlobalAdmin(IAuthProvider authProvider, string username, string password)
    {
        return await authProvider.RegisterUser(new RegisterUserModel
        {
            Username = username,
            Password = password
        });
    }

    private static void GrantRole(IUsersManager usersManager, int id, int roleId)
    {
        usersManager.UpdateUsersRole(id, roleId);
    }

    public static async Task ConfigureApplication(IApplicationBuilder app, DigitalKeyMarketSettings settings)
    {
        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
        var dbContextFactory =
            (IDbContextFactory<DigitalKeyMarketDbContext>)scope.ServiceProvider.GetRequiredService(
                typeof(IDbContextFactory<DigitalKeyMarketDbContext>));
        var roles = await InitializeRoles(dbContextFactory);

        var usersProvider = (IUsersProvider)scope.ServiceProvider.GetRequiredService(typeof(IUsersProvider));
        if (!usersProvider.GetUsers(new FilterUserModel { UsernamePart = settings.MasterAdminData.Username }).Any())
        {
            var authProvider = (IAuthProvider)scope.ServiceProvider.GetRequiredService(typeof(IAuthProvider));
            var adminModel = await CreateGlobalAdmin(authProvider, settings.MasterAdminData.Username,
                settings.MasterAdminData.Password);

            var usersManager = (IUsersManager)scope.ServiceProvider.GetRequiredService(typeof(IUsersManager));
            GrantRole(usersManager, adminModel.Id, roles.Find(x => x.Name == "MasterAdmin").Id);
        }
    }
}