using FluentValidation;

namespace Sportshop.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("The Id field can not be null or empty.");
        }
    }
}
