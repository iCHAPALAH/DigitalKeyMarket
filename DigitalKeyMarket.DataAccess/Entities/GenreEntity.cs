using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Genre")]
public class GenreEntity : BaseEntity
{
    public string Name { get; set; }
    
    public List<GameEntity> Games { get; set; }
}