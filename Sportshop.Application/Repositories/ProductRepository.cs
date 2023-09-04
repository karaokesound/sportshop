using Sportshop.Domain.Entities;
using Sportshop.Persistence.Context;

namespace Sportshop.Application.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SportshopDbContext _context;

        public ProductRepository(SportshopDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
        }

        public Task UpdateProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task PartiallyUpdateProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
