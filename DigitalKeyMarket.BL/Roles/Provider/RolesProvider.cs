using AutoMapper;
using DigitalKeyMarket.BL.Roles.Exceptions;
using DigitalKeyMarket.BL.Roles.Model;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;

namespace DigitalKeyMarket.BL.Roles.Provider;

public class RolesProvider(IRepository<RoleEntity> rolesRepository, IMapper mapper) : IRolesProvider
{
    public IEnumerable<RoleModel> GetRoles(RoleFilterModel? filter = null)
    {
        var namePart = filter?.NamePart;
        
        var roles = rolesRepository.GetAll(r =>
            r.Name == null || namePart == null || r.Name.Contains(namePart));

        return mapper.Map<IEnumerable<RoleModel>>(roles);
    }
}