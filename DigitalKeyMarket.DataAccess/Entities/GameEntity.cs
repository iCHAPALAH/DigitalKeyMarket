using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalKeyMarket.DataAccess.Entities;

[Table("Game")]
public class GameEntity : BaseEntity
{
    public string Name { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public int AgeRestriction { get; set; }
    public string? Description { get; set; }
    
    public List<GenreEntity> Genres { get; set; }
    public List<ItemEntity> Items { get; set; }
}