using Sportshop.Domain.Entities;

namespace Sportshop.Application.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(ProductEntity product);

        Task<List<ProductEntity>> GetProductsAsync();

        Task<ProductEntity> GetProductAsync(Guid productId);

        Task UpdateProductAsync();

        Task PartiallyUpdateProductAsync();

        Task DeleteProductAsync();

        Task<bool> SaveChangesAsync();
    }
}
