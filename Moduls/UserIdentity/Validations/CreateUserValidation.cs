using FluentValidation;
using SystemManagementMovie.Moduls.UserIdentity.Commands.CommandRequest;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Moduls.UserIdentity.Validations;

public class CreateUserValidation : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidation()
    {
        RuleFor(u=>u.UserBaseInfo.FullName)
            .NotEmpty().WithMessage("FullName mustn't be empty")
            .Length(4, 30).WithMessage("FullName must be between 4 and 30 characters.");

        RuleFor(u => u.UserBaseInfo.Age)
            .NotEmpty().WithMessage("Age mustn't be empty")
            .GreaterThan(0).WithMessage("Age must be greater than 0.");

        RuleFor(u => u.UserBaseInfo.Email)
            .NotEmpty().WithMessage("Email mustn't be empty")
            .EmailAddress();
        
        RuleFor(u=>u.UserBaseInfo.HasPremium)
            .NotEmpty().WithMessage("Premium mustn't be empty")
            .Must(b => b == true || b == false).WithMessage("Premium must be true or false.");
    }
}