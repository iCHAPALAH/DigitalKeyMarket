using AutoMapper;
using DigitalKeyMarket.BL.Users.Exceptions;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;

namespace DigitalKeyMarket.BL.Users.Manager;

public class UsersManager : IUsersManager
{
    private readonly IRepository<UserEntity> _usersRepository;
    private readonly IMapper _mapper;

    public UsersManager(IRepository<UserEntity> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    
    public UserModel CreateUser(CreateUserModel createUserModel)
    {
        var user = _mapper.Map<UserEntity>(createUserModel);
        user = _usersRepository.Save(user);
        return _mapper.Map<UserModel>(user);
    }

    public UserModel UpdateUser(UpdateUserModel updateUserModel)
    {
        var user = _mapper.Map<UserEntity>(updateUserModel);
        user = _usersRepository.Save(user);
        return _mapper.Map<UserModel>(user);
    }

    public void DeleteUser(int id)
    {
        var user = _usersRepository.GetById(id);
        if (user == null)
            throw new UserNotFoundException("User does not exist.");
            
        _usersRepository.Delete(user);
    }
}