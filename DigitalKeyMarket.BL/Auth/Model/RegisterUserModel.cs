namespace DigitalKeyMarket.BL.Auth.Model;

public class RegisterUserModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateOnly Birthday { get; set; }
}