using AutoMapper;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.DataAccess.Entities;

namespace DigitalKeyMarket.BL.Mappers;

public class UsersBLProfile : Profile
{
    public UsersBLProfile()
    {
        CreateMap<UserEntity, UserModel>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.ExternalId, opt => opt.MapFrom(src => src.ExternalId))
            .ForMember(x => x.CreationTime, opt => opt.MapFrom(src => src.CreationTime))
            .ForMember(x => x.ModificationTime, opt => opt.MapFrom(src => src.ModificationTime))
            .ForMember(x => x.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
            .ForMember(x => x.Birthday, opt => opt.MapFrom(src => src.Birthday))
            .ForMember(x => x.IsVerified, opt => opt.MapFrom(src => src.IsVerified))
            .ForMember(x => x.RoleId, opt => opt.MapFrom(src => src.RoleId));
        
        CreateMap<CreateUserModel, UserEntity>()
            .ForMember(x => x.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
            .ForMember(x => x.Birthday, opt => opt.MapFrom(src => src.Birthday))
            .ForMember(x => x.RoleId, opt => opt.MapFrom(src => src.RoleId));
        
        CreateMap<UpdateUserModel, UserEntity>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
            .ForMember(x => x.Birthday, opt => opt.MapFrom(src => src.Birthday))
            .ForMember(x => x.IsVerified, opt => opt.MapFrom(src => src.IsVerified))
            .ForMember(x => x.RoleId, opt => opt.MapFrom(src => src.RoleId));
    }
}