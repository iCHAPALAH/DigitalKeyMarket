using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Playgate")]
public class PlaygateEntity : BaseEntity
{
    public int PlatformId { get; set; }
    public PlatformEntity Platform { get; set; }
    
    public int MarketplaceId { get; set; }
    public MarketplaceEntity Marketplace { get; set; }
    
    public List<ItemEntity> Items { get; set; }
}