using System.Net;
using DigitalKeyMarket.BL.Auth.Model;
using DigitalKeyMarket.BL.Auth.Provider;
using DigitalKeyMarket.BL.Users.Manager;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DigitalKeyMarket.Service.IntegrationTests.Auth;

public class AuthorizeUserTests : HotelChainServiceTestsBase
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

        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var authProvider = scope.ServiceProvider.GetRequiredService<IAuthProvider>();
        var userModel = await authProvider.RegisterUser(registerUserModel);

        var query = $"?Username={registerUserModel.Username}"
                    + $"&Password={registerUserModel.Password}";
        var requestUri =
            DigitalKeyMarketApiEndpoints.AuthorizeUserEndpoint + query;
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseContentJson = await response.Content.ReadAsStringAsync();
        var content = JsonConvert.DeserializeObject<TokensResponse>(responseContentJson);

        content.Should().NotBeNull();
        content.AccessToken.Should().NotBeNull();
        content.RefreshToken.Should().NotBeNull();

        var usersManager = scope.ServiceProvider.GetRequiredService<IUsersManager>();
        usersManager.DeleteUser(userModel.Id);
    }

    [Test]
    public async Task AuthorizeWithoutRegistrationTest()
    {
        const string userName = "JohnDoe";
        const string password = "J0hnD0eR0cks!";

        const string query = $"?username={userName}"
                             + $"&password={password}";
        const string requestUri = DigitalKeyMarketApiEndpoints.AuthorizeUserEndpoint + query;
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task AuthorizeWithWrongDataTest()
    {
        var registerUserModel = new RegisterUserModel
        {
            Username = "JohnDoe",
            Password = "J0hnD0eR0cks!",
            Email = "JohnDoe@gmail.com",
            Birthday = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-20))
        };

        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var authProvider = scope.ServiceProvider.GetRequiredService<IAuthProvider>();
        var userModel = await authProvider.RegisterUser(registerUserModel);

        const string wrongUserName = "John_Doe";
        var wrongQuery1 = $"?username={wrongUserName}"
                    + $"&password={registerUserModel.Password}";
        var requestUri1 =
            DigitalKeyMarketApiEndpoints.AuthorizeUserEndpoint + wrongQuery1;
        var request1 = new HttpRequestMessage(HttpMethod.Get, requestUri1);

        const string wrongPassword = "J0hnD0eR0cks";
        var wrongQuery2 = $"?username={registerUserModel.Username}"
                          + $"&password={wrongPassword}";
        var requestUri2 =
            DigitalKeyMarketApiEndpoints.AuthorizeUserEndpoint + wrongQuery2;
        var request2 = new HttpRequestMessage(HttpMethod.Get, requestUri2);

        var client = TestHttpClient;

        var response = await client.SendAsync(request1);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        response = await client.SendAsync(request2);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var usersManager = scope.ServiceProvider.GetRequiredService<IUsersManager>();
        usersManager.DeleteUser(userModel.Id);
    }
}