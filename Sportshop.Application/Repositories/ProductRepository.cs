using Microsoft.EntityFrameworkCore;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;
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

        public async Task CreateProductAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<List<ProductEntity>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity?> GetProductAsync(Guid productId)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            return product;
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
