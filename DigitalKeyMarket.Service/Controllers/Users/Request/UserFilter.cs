namespace DigitalKeyMarket.Service.Controllers.Users.Model;

public class UserFilter
{
    public string? UsernamePart { get; set; }
    public string? EmailPart { get; set; }
    
    public int? RoleId { get; set; }
}