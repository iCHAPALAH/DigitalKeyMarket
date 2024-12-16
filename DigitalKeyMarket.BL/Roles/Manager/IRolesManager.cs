using DigitalKeyMarket.BL.Roles.Model;

namespace DigitalKeyMarket.BL.Roles.Manager;

public interface IRolesManager
{
    RoleModel CreateRole(CreateRoleModel createRoleModel);
    RoleModel UpdateRole(UpdateRoleModel updateRoleModel);
    void DeleteRole(int id);
}