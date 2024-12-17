using DigitalKeyMarket.BL.Auth.Model;
using DigitalKeyMarket.BL.Users.Model;

namespace DigitalKeyMarket.BL.Auth.Provider;

public interface IAuthProvider
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokensResponse> AuthorizeUser(AuthorizeUserModel model);
}