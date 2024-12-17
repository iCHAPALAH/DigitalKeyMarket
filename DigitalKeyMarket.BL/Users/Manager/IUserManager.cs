using DigitalKeyMarket.BL.Users.Model;

namespace DigitalKeyMarket.BL.Users.Manager;

public interface IUsersManager
{
    UserModel UpdateUser(int userId, UpdateUserModel update);
    UserModel UpdateUsersRole(int userId, int roleId);
    UserModel VerifyUser(int userId);
    void DeleteUser(int userId);
}