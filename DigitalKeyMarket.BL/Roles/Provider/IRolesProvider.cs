using DigitalKeyMarket.BL.Roles.Model;

namespace DigitalKeyMarket.BL.Roles.Provider;

public interface IRolesProvider
{
    IEnumerable<RoleModel> GetRoles(RoleFilterModel? filter = null);
}