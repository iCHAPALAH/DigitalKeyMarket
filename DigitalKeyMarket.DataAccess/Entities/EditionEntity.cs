using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Edition")]
public class EditionEntity : BaseEntity
{
    public string Name { get; set; }
    
    public List<ItemEntity> Items { get; set; }
}