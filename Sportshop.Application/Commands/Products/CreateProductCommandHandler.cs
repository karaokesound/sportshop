﻿using AutoMapper;
using MediatR;
using Sportshop.Application.ReadModels.Responses;
using Sportshop.Application.Repositories;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Commands.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            bool validation = await ProductDataValidation(request);

            if (!validation) return null;

            var product = await AppendThumbnailIdToProduct(request);

            await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(product);
        }

        private async Task<bool> ProductDataValidation(CreateProductCommand requestedProduct)
        {
            return true;
        }

        private async Task<ProductEntity> AppendThumbnailIdToProduct(CreateProductCommand requestedProduct)
        {
            ThumbnailModel thumbnail = new ThumbnailModel();
            thumbnail.Id = Guid.NewGuid();
            thumbnail.Content = requestedProduct.Thumbnail.Content;

            string[] productName = requestedProduct.Name.Split(" ");
            string joinedProductName = string.Empty;

            if (productName.Length < 4)
            {
                joinedProductName = string.Join("_", productName);
            }
            else
            {
                productName = productName
                .Take(3)
                .ToArray();

                joinedProductName = string.Join("_", productName);
            }

            thumbnail.FileName = $"{thumbnail.Id}-{joinedProductName}";
            string path = Path.Combine(@"C:\\Users\\karao\\source\\repos\\sportshop\\Sportshop.Persistence\\Thumbnails",
               thumbnail.FileName);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await thumbnail.Content.CopyToAsync(stream);
            }

            var product = _mapper.Map<ProductEntity>(requestedProduct);
            product.Id = Guid.NewGuid();
            product.ThumbnailId = thumbnail.Id;

            return product;
        }
    }
}
