using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Marketplace")]
public class MarketplaceEntity : BaseEntity
{
    public string Name { get; set; }
    
    public List<PlaygateEntity> Platforms { get; set; }
}