using DigitalKeyMarket.BL.Users.Model;

namespace DigitalKeyMarket.BL.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers();
    UserModel GetUserInfo(int id);
}