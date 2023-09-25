using FluentValidation;

namespace Sportshop.Application.Commands.Authentication.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.Username)
                .NotNull().WithMessage("The Username field can not be null or empty.")
                .NotEmpty().WithMessage("The Username field can not be null or empty.");

            RuleFor(l => l.Password)
                .NotNull().WithMessage("The Password field can not be null or empty.")
                .NotEmpty().WithMessage("The Password field can not be null or empty.");
        }
    }
}
