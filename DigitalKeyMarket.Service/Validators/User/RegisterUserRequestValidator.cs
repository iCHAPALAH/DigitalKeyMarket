using DigitalKeyMarket.Service.Controllers.Auth.Model;
using FluentValidation;

namespace DigitalKeyMarket.Service.Validators.User;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .Matches(@"^\w+$")
            .WithMessage("Username must be valid");
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .WithMessage("Password must be valid");
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email must be valid");
        RuleFor(x => x.Birthday)
            .NotEmpty()
            .Must(y => y < DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Birthday must be valid");
    }
}