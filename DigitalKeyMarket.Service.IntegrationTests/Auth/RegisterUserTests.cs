using System.Net;
using System.Net.Http.Json;
using DigitalKeyMarket.BL.Auth.Model;
using DigitalKeyMarket.BL.Auth.Provider;
using DigitalKeyMarket.BL.Users.Manager;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace DigitalKeyMarket.Service.IntegrationTests.Auth;

public class RegisterUserTests : HotelChainServiceTestsBase
{
    [Test]
    public async Task HappyPathTest()
    {
        var registerUserModel = new RegisterUserModel
        {
            Username = "JohnDoe",
            Email = "JohnDoe@gmail.com",
            Password = "J0hnD0eR0cks!",
            Birthday = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-20))
        };

        var client = TestHttpClient;
        var response = await client.PostAsJsonAsync(DigitalKeyMarketApiEndpoints.RegisterUserEndpoint, registerUserModel);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<UserEntity>>();
        var userEntities = userRepository.GetAll(e => e.UserName == registerUserModel.Username)
            .ToList();
        userRepository.Delete(userEntities[0]);
    }

    [Test]
    public async Task RegisterUserThatAlreadyExistsTest()
    {
        var registerUserModel = new RegisterUserModel
        {
            Username = "JohnDoe",
            Email = "JohnDoe@gmail.com",
            Password = "J0hnD0eR0cks!",
            Birthday = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-20))
        };

        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var authProvider = scope.ServiceProvider.GetRequiredService<IAuthProvider>();
        var userModel = await authProvider.RegisterUser(registerUserModel);

        var client = TestHttpClient;
        var response = await client.PostAsJsonAsync(DigitalKeyMarketApiEndpoints.RegisterUserEndpoint, registerUserModel);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var userManager = scope.ServiceProvider.GetRequiredService<IUsersManager>();
        userManager.DeleteUser(userModel.Id);
    }

    [Test]
    public async Task RegisterUserWithWrongData()
    {
        var registerUserModel = new RegisterUserModel
        {
            Username = "JohnDoe",
            Email = "JohnDoe@gmail.com",
            Password = "J0hnD0eR0cks!",
            Birthday = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-20))
        };

        var client = TestHttpClient;

        registerUserModel.Password = "1";
        var response = await client.PostAsJsonAsync(DigitalKeyMarketApiEndpoints.RegisterUserEndpoint, registerUserModel);
        registerUserModel.Password = "J0hnD0eR0cks!";

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        registerUserModel.Email = "1";
        response = await client.PostAsJsonAsync(DigitalKeyMarketApiEndpoints.RegisterUserEndpoint, registerUserModel);
        registerUserModel.Email = "JohnDoe@gmail.com";

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        registerUserModel.Birthday = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(20));
        response = await client.PostAsJsonAsync(DigitalKeyMarketApiEndpoints.RegisterUserEndpoint, registerUserModel);
        registerUserModel.Birthday = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-20));

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}