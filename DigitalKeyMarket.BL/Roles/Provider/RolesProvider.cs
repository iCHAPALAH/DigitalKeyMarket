using AutoMapper;
using DigitalKeyMarket.BL.Roles.Exceptions;
using DigitalKeyMarket.BL.Roles.Model;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;

namespace DigitalKeyMarket.BL.Roles.Provider;

public class RolesProvider : IRolesProvider
{
    private readonly IRepository<RoleEntity> _rolesRepository;
    private readonly IMapper _mapper;

    public RolesProvider(IRepository<RoleEntity> rolesRepository, IMapper mapper)
    {
        _rolesRepository = rolesRepository;
        _mapper = mapper;
    }

    public IEnumerable<RoleModel> GetRoles()
    {
        var roles = _rolesRepository.GetAll().ToList();

        return _mapper.Map<IEnumerable<RoleModel>>(roles);
    }

    public RoleModel GetRoleInfo(int id)
    {
        var role = _rolesRepository.GetById(id);
        if (role == null)
            throw new RoleNotFoundException("Role does not exist.");

        return _mapper.Map<RoleModel>(role);
    }
}