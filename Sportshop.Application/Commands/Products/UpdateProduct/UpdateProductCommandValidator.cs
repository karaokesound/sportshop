using FluentValidation;

namespace Sportshop.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            // Null values are validated by API, there is no need to define it here

            RuleFor(p => p.Id)
                .NotNull().WithMessage("The Id field can not be null or empty.")
                .NotEmpty().WithMessage("The Id field can not be null or empty.");

            RuleFor(p => p.Name)
                .MinimumLength(3).WithMessage("The Name field must be between 3-100 letters length.")
                .MaximumLength(100).WithMessage("The Name field must be between 3-100 letters length.");

            RuleFor(p => p.Description)
                .MinimumLength(3).WithMessage("The Description field must be between 3-500 letters length.")
                .MaximumLength(500).WithMessage("The Description field must be between 3-500 letters length.");

            RuleFor(p => p.Price)
                .Must(p => p <= 20000 && p >= 1).WithMessage("The Price field must be between 1-20000.");

            RuleFor(p => p.Quantity)
                .Must(p => p <= 1000 && p >= 1).WithMessage("The Quantity field must be between 1-1000.");

            RuleFor(p => p.Seller)
                .MinimumLength(3).WithMessage("The Seller field must be between 3-25 letters length.")
                .MaximumLength(25).WithMessage("The Seller field must be between 3-25 letters length.");
        }
    }
}
