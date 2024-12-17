namespace DigitalKeyMarket.BL.Users.Model;

public class UserModel
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateOnly Birthday { get; set; }
    public bool IsVerified { get; set; }
    public int RoleId { get; set; }
}