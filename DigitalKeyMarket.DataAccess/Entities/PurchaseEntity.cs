using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Purchase")]
public class PurchaseEntity : BaseEntity
{
    public DateTime Date { get; set; }
    public int Price { get; set; }
    
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    public int ItemId { get; set; }
    public ItemEntity Item { get; set; }
}