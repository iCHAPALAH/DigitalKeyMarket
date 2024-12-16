namespace DigitalKeyMarket.BL.Roles.Exceptions;

public class RoleNotFoundException : ApplicationException
{
    public RoleNotFoundException() { }
    public RoleNotFoundException(string message) : base(message) { }
}