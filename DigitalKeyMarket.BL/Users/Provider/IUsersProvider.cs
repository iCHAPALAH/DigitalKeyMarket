using DigitalKeyMarket.BL.Users.Model;

namespace DigitalKeyMarket.BL.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers(FilterUserModel? filter = null);
    UserModel GetUserInfo(int id);
}