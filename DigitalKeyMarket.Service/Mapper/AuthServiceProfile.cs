using AutoMapper;
using DigitalKeyMarket.BL.Auth.Model;
using DigitalKeyMarket.Service.Controllers.Auth.Model;

namespace DigitalKeyMarket.Service.Mapper;

public class AuthServiceProfile : Profile
{
    public AuthServiceProfile()
    {
        CreateMap<RegisterUserRequest, RegisterUserModel>();
        CreateMap<AuthorizeUserRequest, AuthorizeUserModel>();
    }
}