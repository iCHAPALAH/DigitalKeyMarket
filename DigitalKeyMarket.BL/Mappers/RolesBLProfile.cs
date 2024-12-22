using AutoMapper;
using DigitalKeyMarket.BL.Roles.Model;
using DigitalKeyMarket.DataAccess.Entities;

namespace DigitalKeyMarket.BL.Mappers;

public class RolesBLProfile : Profile
{
    public RolesBLProfile()
    {
        CreateMap<RoleEntity, RoleModel>();
    }
}