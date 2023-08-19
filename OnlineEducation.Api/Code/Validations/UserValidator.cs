using FluentValidation;
using OnlineEducation.Model;

namespace OnlineEducation.Code.Validations;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(k => k.Username).NotEmpty().WithMessage("Your password cannot be empty");
        RuleFor(k => k.Username).EmailAddress().WithMessage("Wrong email adress");
        RuleFor(k => k.Password).Length(8,15).WithMessage("Your password length must be at least 8, maximum 20");
        RuleFor(k => k.Password).Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
    }
}