using AutoMapper;
using MediatR;
using Sportshop.Application.Repositories;
using Sportshop.Application.Services.Product;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IProductService productService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var thumbnail = new ThumbnailModel()
            {
                Content = request.Thumbnail.Content
            };

            Guid thumbnailId = await _productService.AppendThumbnailAndGetIdAsync(thumbnail, request.Name);

            var productEntity = new ProductEntity()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                Seller = request.Seller,
                ThumbnailId = thumbnailId,
                // User and UserId are null at this stage
            };

            await _productRepository.CreateProductAsync(productEntity);
            await _productRepository.SaveChangesAsync();

            var response = _mapper.Map<CreateProductCommandResponse>(productEntity);
            response.Message = "Success! You've created the new product.";

            return response;
        }
    }
}
