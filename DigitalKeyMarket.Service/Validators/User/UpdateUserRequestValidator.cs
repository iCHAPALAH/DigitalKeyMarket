using FluentValidation;
using DigitalKeyMarket.Service.Controllers.Users.Model;

namespace DigitalKeyMarket.Service.Validators.User;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id must be valid");
        RuleFor(x => x.Username)
            .Matches(@"^\w{3,30}$")
            .WithMessage("Username must be valid");
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email must be valid");
        RuleFor(x => x.PasswordHash)
            .Matches("^[a-fA-F0-9]{64}$")
            .WithMessage("Password hash must be valid");
        RuleFor(x => x.Birthday)
            .Must(y => y < DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Birthday must be valid");
    }
}