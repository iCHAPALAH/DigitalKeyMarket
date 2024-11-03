using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Item")]
public class ItemEntity : BaseEntity
{
    public int Stock { get; set; }
    public int Price { get; set; }
    
    public int GameId { get; set; }
    public GameEntity Game { get; set; }
    
    public int PlaygateId { get; set; }
    public PlaygateEntity Playgate { get; set; }
    
    public int EditionId { get; set; }
    public EditionEntity Edition { get; set; }
    
    public List<PurchaseEntity> Users { get; set; }
}