using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("User")]
public class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateOnly Birthday { get; set; }
    public bool IsVerified { get; set; }
    
    public List<RoleEntity> Roles { get; set; }
    public List<PurchaseEntity> Purchases { get; set; }
}