namespace DigitalKeyMarket.BL.Users.Exceptions;

public class UserAlreadyVerifiedException : Exception
{
    public UserAlreadyVerifiedException() { }
    public UserAlreadyVerifiedException(string message) : base(message) { }
}