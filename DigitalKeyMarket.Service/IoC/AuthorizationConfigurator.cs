﻿using DigitalKeyMarket.DataAccess;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.Service.Settings;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DigitalKeyMarket.Service.IoC;

public static class AuthorizationConfigurator
{
    public static void ConfigureServices(IServiceCollection services, DigitalKeyMarketSettings settings)
    {
        IdentityModelEventSource.ShowPII = true;
        services.AddIdentity<UserEntity, RoleEntity>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
            })
            .AddEntityFrameworkStores<DigitalKeyMarketDbContext>()
            .AddSignInManager<SignInManager<UserEntity>>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddInMemoryApiScopes([new ApiScope(settings.ApiName)])
            .AddInMemoryClients([
                new Client
                {
                    ClientName = settings.ClientId,
                    ClientId = settings.ClientId,
                    Enabled = true,
                    AllowOfflineAccess = true,
                    AllowedGrantTypes = [
                        GrantType.ClientCredentials,
                        GrantType.ResourceOwnerPassword],
                    ClientSecrets = [new Secret(settings.ClientSecret.Sha256())],
                    AllowedScopes = [settings.ApiName]
                }
            ])
            .AddAspNetIdentity<UserEntity>();
        
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        ).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.RequireHttpsMetadata = false;
            options.Authority = settings.IdentityServerUri;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            options.Audience = settings.ApiName;
        });
        
        services.AddAuthorization();
    }
    
    public static void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}