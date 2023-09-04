using Sportshop.Domain.Entities;

namespace Sportshop.Application.Repositories
{
    public interface IProductRepository
    {
        Task AddProductAsync(ProductEntity product);

        Task UpdateProductAsync();

        Task PartiallyUpdateProductAsync();

        Task DeleteProductAsync();

        Task<bool> SaveChangesAsync();
    }
}
