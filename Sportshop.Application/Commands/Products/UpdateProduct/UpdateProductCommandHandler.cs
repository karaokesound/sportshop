using AutoMapper;
using MediatR;
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

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository, 
            IProductService productService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productService = productService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, 
            CancellationToken cancellationToken)
        {
            var productEntity = await _productRepository.GetProductAsync(request.Id);

            if (productEntity == null) return null!;

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

            var response = new UpdateProductCommandResponse();
            response.Message = "Success!";

            return response;
        }
    }
}
