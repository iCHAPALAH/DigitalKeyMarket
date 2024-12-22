using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Role")]
public class RoleEntity : IdentityRole<int>, IBaseEntity
{
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    
    public List<UserEntity> Users { get; set; }
}