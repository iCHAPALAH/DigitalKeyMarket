using AutoMapper;
using DigitalKeyMarket.BL.Auth.Model;
using DigitalKeyMarket.DataAccess.Entities;

namespace DigitalKeyMarket.BL.Mappers;

public class AuthBLProfile : Profile
{
    public AuthBLProfile()
    {
        CreateMap<RegisterUserModel, UserEntity>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.IsVerified, y => y.Ignore())
            .ForMember(x => x.RoleId, y => y.Ignore());
    }
}