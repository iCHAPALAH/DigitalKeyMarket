using FluentValidation;
using DigitalKeyMarket.BL.Roles.Model;

namespace DigitalKeyMarket.Service.Validators.Role;

public class UpdateRoleValidator : AbstractValidator<UpdateRoleModel>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id must be valid");
        RuleFor(x => x.Name)
            .NotEmpty()
            .Matches(@"^\w+$")
            .WithMessage("Name must be valid");
    }
}