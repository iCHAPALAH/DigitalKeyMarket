using AutoMapper;
using DigitalKeyMarket.BL.Auth.Model;
using DigitalKeyMarket.BL.Auth.Exceptions;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.BL.Users.Exceptions;
using DigitalKeyMarket.DataAccess.Entities;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;

namespace DigitalKeyMarket.BL.Auth.Provider;

public class AuthProvider(
    SignInManager<UserEntity> signInManager,
    UserManager<UserEntity> userManager,
    IHttpClientFactory httpClientFactory,
    IMapper mapper,
    string identityServerUri,
    string clientId,
    string clientSecret
)
    : IAuthProvider
{
    public async Task<UserModel> RegisterUser(RegisterUserModel model)
    {
        if (await userManager.FindByNameAsync(model.Username) is not null)
            throw new UserAlreadyExistsException();

        var userEntity = mapper.Map<UserEntity>(model);
        userEntity.ExternalId = Guid.NewGuid();
        userEntity.CreationTime = DateTime.UtcNow;
        userEntity.ModificationTime = DateTime.UtcNow;
        userEntity.IsVerified = false;

        var createResult = await userManager.CreateAsync(userEntity, model.Password);
        if (!createResult.Succeeded)
            throw new UserCreationException();

        var user = await userManager.FindByNameAsync(model.Username);
        return mapper.Map<UserModel>(user);
    }

    public async Task<TokensResponse> AuthorizeUser(AuthorizeUserModel model)
    {
        var userByName = await userManager.FindByNameAsync(model.Username);
        if (userByName is null)
            throw new UserNotFoundException();

        var checkPasswordResult = await signInManager.CheckPasswordSignInAsync(userByName, model.Password, false);
        if (!checkPasswordResult.Succeeded)
            throw new WrongPasswordException();

        var client = httpClientFactory.CreateClient();
        var endpoints = await client.GetDiscoveryDocumentAsync(identityServerUri);
        if (endpoints.IsError)
            throw new Exception(endpoints.Error);

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = endpoints.TokenEndpoint,
            ClientId = clientId,
            ClientSecret = clientSecret,
            UserName = model.Username,
            Password = model.Password,
            Scope = "api offline_access"
        });
        if (tokenResponse.IsError)
            throw new Exception(tokenResponse.Error);

        return new TokensResponse
        {
            AccessToken = tokenResponse.AccessToken,
            RefreshToken = tokenResponse.RefreshToken
        };
    }
}