namespace DigitalKeyMarket.Service.Controllers.Auth.Model;

public class RegisterUserRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateOnly Birthday { get; set; }
}