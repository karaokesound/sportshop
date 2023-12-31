﻿using Sportshop.Domain.Entities;

namespace Sportshop.Application.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(ProductEntity product);

        Task<List<ProductEntity>> GetProductsAsync();

        Task<ProductEntity> GetProductAsync(Guid productId);

        Task<Guid> GetProductsThumbnailIdAsync(Guid productThumbnailId);

        Task PartiallyUpdateProductAsync();

        void DeleteProduct(ProductEntity product);

        Task<bool> SaveChangesAsync();
    }
}
