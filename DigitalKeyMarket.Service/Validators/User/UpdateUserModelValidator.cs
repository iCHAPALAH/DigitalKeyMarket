using FluentValidation;
using DigitalKeyMarket.BL.Users.Model;

namespace DigitalKeyMarket.Service.Validators.User;

public class UpdateUserModelValidator: AbstractValidator<UpdateUserModel>
{
    public UpdateUserModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id must be valid");
        RuleFor(x => x.Username)
            .NotEmpty()
            .Matches(@"^\w{3,30}$")
            .WithMessage("Username must be valid");
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email must be valid");
        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .Matches("^[a-fA-F0-9]{64}$")
            .WithMessage("Password hash must be valid");
        RuleFor(x => x.Birthday)
            .NotEmpty()
            .WithMessage("Birthday must be valid");
        // RuleFor(x => x.IsVerified)
        //     .NotEmpty()
        //     .WithMessage("IsVerified must be valid");
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("Role must be valid");
    }
}