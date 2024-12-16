using AutoMapper;
using DigitalKeyMarket.BL.Roles.Model;
using DigitalKeyMarket.DataAccess.Entities;

namespace DigitalKeyMarket.BL.Mappers;

public class RolesBLProfile : Profile
{
    public RolesBLProfile()
    {
        CreateMap<RoleEntity, RoleModel>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.ExternalId, opt => opt.MapFrom(src => src.ExternalId))
            .ForMember(x => x.CreationTime, opt => opt.MapFrom(src => src.CreationTime))
            .ForMember(x => x.ModificationTime, opt => opt.MapFrom(src => src.ModificationTime))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<CreateRoleModel, RoleEntity>()
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateRoleModel, RoleEntity>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name));
    }
}