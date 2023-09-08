using MediatR;
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

            if (product == null) return null!;

            _productRepository.DeleteProduct(product);
            await _productRepository.SaveChangesAsync();

            var response = new DeleteProductCommandResponse()
            {
                Response = "Success! You've deleted the product!",
                Name = product.Name,
                Seller = product.Seller
            };

            return response;
        }
    }
}
