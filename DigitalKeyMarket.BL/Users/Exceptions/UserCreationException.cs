namespace DigitalKeyMarket.BL.Users.Exceptions;

public class UserCreationException : Exception
{
    public UserCreationException() { }
    public UserCreationException(string message) : base(message) { }
}