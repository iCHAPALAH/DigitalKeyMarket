using FluentValidation;
using DigitalKeyMarket.BL.Roles.Model;

namespace DigitalKeyMarket.Service.Validators.Role;

public class CreateRoleValidator : AbstractValidator<CreateRoleModel>
{
    public CreateRoleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Matches(@"^\w+$")
            .WithMessage("Name must be valid");
    }
}