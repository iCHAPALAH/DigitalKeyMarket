using DigitalKeyMarket.Service.Controllers.Users.Model;
using FluentValidation;

namespace DigitalKeyMarket.Service.Validators.User;

public class UpdateUsersRoleRequestValidator : AbstractValidator<UpdateUsersRoleRequest>
{
    public UpdateUsersRoleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id must be valid");
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("RoleId must be valid");
    }
}