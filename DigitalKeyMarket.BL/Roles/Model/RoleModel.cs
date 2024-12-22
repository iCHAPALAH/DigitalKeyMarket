namespace DigitalKeyMarket.BL.Roles.Model;

public class RoleModel
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    public string? Name { get; set; }
}