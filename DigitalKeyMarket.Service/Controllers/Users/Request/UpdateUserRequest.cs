namespace DigitalKeyMarket.Service.Controllers.Users.Model;

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public DateOnly? Birthday { get; set; }
}