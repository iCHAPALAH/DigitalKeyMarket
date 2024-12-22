using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("User")]
public class UserEntity : IdentityUser<int>, IBaseEntity
{
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    
    public string Username { get; set; }
    public DateOnly Birthday { get; set; }
    public bool IsVerified { get; set; }
    
    public int RoleId { get; set; }
    public RoleEntity Role { get; set; }
    public List<PurchaseEntity> Purchases { get; set; }
}