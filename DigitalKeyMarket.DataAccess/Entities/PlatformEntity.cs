using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Platform")]
public class PlatformEntity : BaseEntity
{
    public string Name { get; set; }
    
    public List<PlaygateEntity> Marketplaces { get; set; }
}