using MediatR;
using Sportshop.Application.Exceptions;
using Sportshop.Application.Repositories;

namespace Sportshop.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductAsync(request.Id);

            if (product == null) throw new ProductNotFoundException(
                $"Product with id {request.Id} was not found.");

            _productRepository.DeleteProduct(product);
            await _productRepository.SaveChangesAsync();

            var response = new DeleteProductCommandResponse()
            {
                Message = "Success! You've deleted the product!",
                Name = product.Name,
                Price = product.Price,
                Seller = product.Seller
            };

            return response;
        }
    }
}
