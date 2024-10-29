using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Item")]
public class ItemEntity : BaseEntity
{
    public int Stock { get; set; }
    public int Price { get; set; }
    
    public Guid GameId { get; set; }
    public GameEntity Game { get; set; }
    
    public Guid PlaygateId { get; set; }
    public PlaygateEntity Playgate { get; set; }
    
    public Guid EditionId { get; set; }
    public EditionEntity Edition { get; set; }
    
    public List<PurchaseEntity> Users { get; set; }
}