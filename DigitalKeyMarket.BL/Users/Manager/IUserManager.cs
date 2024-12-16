using DigitalKeyMarket.BL.Users.Model;

namespace DigitalKeyMarket.BL.Users.Manager;

public interface IUsersManager
{
    UserModel CreateUser(CreateUserModel createModel);
    UserModel UpdateUser(UpdateUserModel updateModel);
    void DeleteUser(int id);
}