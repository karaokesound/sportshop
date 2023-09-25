using AutoMapper;
using MediatR;
using Sportshop.Application.Exceptions;
using Sportshop.Application.Repositories;
using Sportshop.Application.Services.Product;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository, IProductService productService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productService = productService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _productRepository.GetProductAsync(request.Id);

            if (productEntity == null) throw new ProductNotFoundException(
                $"Product with id {request.Id} was not found.");

            Guid productsThumbnailId = await _productRepository.GetProductsThumbnailIdAsync(productEntity.ThumbnailId);
            _productService.DeleteThumbnail(productsThumbnailId, productEntity.Name);

            var newThumbnail = new ThumbnailModel()
            {
                Content = request.Thumbnail.Content
            };

            Guid newThumbnailId = await _productService.AppendThumbnailAndGetIdAsync(newThumbnail, request.Name);

            // Updating the user
            _mapper.Map(request, productEntity);
            productEntity.ThumbnailId = newThumbnailId;

            await _productRepository.SaveChangesAsync();

            return new UpdateProductCommandResponse()
            {
                Message = "You've successfully updated the product!",
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                Seller = request.Seller,
                ThumbnailId = newThumbnailId
            };
        }
    }
}
