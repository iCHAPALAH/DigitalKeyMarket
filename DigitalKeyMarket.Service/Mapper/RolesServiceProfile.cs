using AutoMapper;
using DigitalKeyMarket.BL.Roles.Model;
using DigitalKeyMarket.Service.Controllers.Roles.Request;

namespace DigitalKeyMarket.Service.Mapper;

public class RolesServiceProfile : Profile
{
    public RolesServiceProfile()
    {
        CreateMap<RoleFilter, RoleFilterModel>();
    }
}