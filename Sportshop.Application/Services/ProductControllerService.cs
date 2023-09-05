using AutoMapper;
using Sportshop.Application.Dtos;
using Sportshop.Application.Dtos.Product;
using Sportshop.Application.Repositories;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;
using System.IO;

namespace Sportshop.Application.Services
{
    public class ProductControllerService : IProductControllerService
    {
        private readonly IMapper _mapper;

        private readonly IProductRepository _productRepository;

        public ProductControllerService(IMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task AddProduct(ProductDto requestedProduct, Thumbnail productThumbnail)
        {
            var product = _mapper.Map<Product>(requestedProduct);
            product.ThumbnailId = productThumbnail.Id;
            product.Id = Guid.NewGuid();

            var productEntity = _mapper.Map<ProductEntity>(product);

            await _productRepository.AddProductAsync(productEntity);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<bool> ProductDataValidation(ProductDto requestedProduct)
        {
            return true;
        }
    }
}
