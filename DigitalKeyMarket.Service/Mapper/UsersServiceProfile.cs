using AutoMapper;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.Service.Controllers.Users.Model;

namespace DigitalKeyMarket.Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UpdateUserRequest, UpdateUserModel>();
        CreateMap<UserFilter, FilterUserModel>();
    }
}