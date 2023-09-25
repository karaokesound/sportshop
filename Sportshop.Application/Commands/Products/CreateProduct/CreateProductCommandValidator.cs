using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Sportshop.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            // Null values are validated by API, there is no need to define it here

            RuleFor(p => p.Name)
                .MinimumLength(3).WithMessage("The Name field must be between 3-100 letters length.")
                .MaximumLength(100).WithMessage("The Name field must be between 3-100 letters length.");

            RuleFor(p => p.Description)
                .MinimumLength(3).WithMessage("The Description field must be between 3-500 letters length.")
                .MaximumLength(500).WithMessage("The Description field must be between 3-500 letters length.");

            RuleFor(p => p.Seller)
                .MinimumLength(3).WithMessage("The Seller field must be between 3-25 letters length.")
                .MaximumLength(25).WithMessage("The Seller field must be between 3-25 letters length.");
        }
    }
}
