using AutoMapper;
using DigitalKeyMarket.BL.Users.Exceptions;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;

namespace DigitalKeyMarket.BL.Users.Provider;

public class UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper) : IUsersProvider
{
    public IEnumerable<UserModel> GetUsers(FilterUserModel? filter = null)
    {
        var usernamePart = filter?.UsernamePart;
        var emailPart = filter?.EmailPart;
        var roleId = filter?.RoleId;
        
        var users = usersRepository.GetAll(u =>
            (usernamePart == null || u.Username.Contains(usernamePart)) &&
            (emailPart == null || u.Username.Contains(emailPart)) &&
            (roleId == null || u.RoleId == roleId));

        return mapper.Map<IEnumerable<UserModel>>(users);
    }

    public UserModel GetUserInfo(int id)
    {
        var user = usersRepository.GetById(id);
        if (user == null)
            throw new UserNotFoundException();

        return mapper.Map<UserModel>(user);
    }
}