using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Playgate")]
public class PlaygateEntity : BaseEntity
{
    public Guid PlatformId { get; set; }
    public PlatformEntity Platform { get; set; }
    
    public Guid MarketplaceId { get; set; }
    public MarketplaceEntity Marketplace { get; set; }
    
    public List<ItemEntity> Items { get; set; }
}