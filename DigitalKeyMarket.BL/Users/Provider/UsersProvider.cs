using AutoMapper;
using DigitalKeyMarket.BL.Users.Exceptions;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;

namespace DigitalKeyMarket.BL.Users.Provider;

public class UsersProvider : IUsersProvider
{
    private readonly IRepository<UserEntity> _usersRepository;
    private readonly IMapper _mapper;
    
    public UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    
    public IEnumerable<UserModel> GetUsers()
    {
        var users = _usersRepository.GetAll().ToList();

        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public UserModel GetUserInfo(int id)
    {
        var user = _usersRepository.GetById(id);
        if (user == null)
            throw new UserNotFoundException("User does not exist.");

        return _mapper.Map<UserModel>(user);
    }
}