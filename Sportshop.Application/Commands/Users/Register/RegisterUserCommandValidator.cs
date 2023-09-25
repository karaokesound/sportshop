using FluentValidation;

namespace Sportshop.Application.Commands.Users.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotNull().WithMessage("The Username field can not be null or empty.")
                .MaximumLength(25).WithMessage("The Username field must be between 3-25 letters length.")
                .MinimumLength(3).WithMessage("The Username field must be between 3-25 letters length.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("The Password field can not be null or empty.")
                .MaximumLength(25).WithMessage("The Password field must be between 3-25 letters length.")
                .MinimumLength(3).WithMessage("The Password field must be between 3-25 letters length.");

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("The FirstName field can not be null or empty.")
                .MaximumLength(25).WithMessage("The FirstName field must be between 3-25 letters length.")
                .MinimumLength(3).WithMessage("The FirstName field must be between 3-25 letters length.");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("The LastName field can not be null or empty.")
                .MaximumLength(25).WithMessage("The LastName field must be between 3-25 letters length.")
                .MinimumLength(3).WithMessage("The LastName field must be between 3-25 letters length.");
             
            RuleFor(x => x.City)
                .NotNull().WithMessage("The City field can not be null or empty.")
                .MaximumLength(25).WithMessage("The Username field must be between 3-25 letters length.")
                .MinimumLength(3).WithMessage("The Username field must be between 3-25 letters length.");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("The Age field can not be null or empty.")
                .Must(x => x > 18).WithMessage("The Age field must be over 18.");
        }
    }
}
