namespace DigitalKeyMarket.BL.Users.Model;

public class UpdateUserModel
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public DateOnly? Birthday { get; set; }
}