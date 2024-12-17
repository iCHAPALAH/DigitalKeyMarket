using AutoMapper;
using DigitalKeyMarket.BL.Roles.Exceptions;
using DigitalKeyMarket.BL.Users.Exceptions;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;

namespace DigitalKeyMarket.BL.Users.Manager;

public class UsersManager(
    IRepository<UserEntity> usersRepository,
    IRepository<RoleEntity> rolesRepository,
    IMapper mapper)
    : IUsersManager
{
    public UserModel UpdateUser(int userId, UpdateUserModel update)
    {
        var entity = usersRepository.GetById(userId);
        if (entity is null)
            throw new UserNotFoundException();

        entity.Username = update.Username ?? entity.Username;
        entity.Email = update.Email ?? entity.Email;
        entity.PasswordHash = update.PasswordHash ?? entity.PasswordHash;
        entity.Birthday = update.Birthday ?? entity.Birthday;

        try
        {
            var user = usersRepository.Save(entity);
            return mapper.Map<UserModel>(user);
        }
        catch (Exception)
        {
            throw new UserAlreadyExistsException();
        }
    }

    public UserModel UpdateUsersRole(int userId, int roleId)
    {
        var userEntity = usersRepository.GetById(userId);
        if (userEntity is null)
            throw new UserNotFoundException();

        var roleEntity = rolesRepository.GetById(roleId);
        if (roleEntity is null)
            throw new RoleNotFoundException();

        userEntity.RoleId = roleId;
        userEntity.Role = roleEntity;
        
        var user = usersRepository.Save(userEntity);
        return mapper.Map<UserModel>(user);
    }

    public UserModel VerifyUser(int userId)
    {
        var userEntity = usersRepository.GetById(userId);
        if (userEntity is null)
            throw new UserNotFoundException();

        if (userEntity.IsVerified)
            throw new UserAlreadyVerifiedException();
        
        userEntity.IsVerified = true;
        
        var user = usersRepository.Save(userEntity);
        return mapper.Map<UserModel>(user);
    }

    public void DeleteUser(int userId)
    {
        var user = usersRepository.GetById(userId);
        if (user == null)
            throw new UserNotFoundException();
            
        usersRepository.Delete(user);
    }
}