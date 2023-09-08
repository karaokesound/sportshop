using MediatR;

namespace Sportshop.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
