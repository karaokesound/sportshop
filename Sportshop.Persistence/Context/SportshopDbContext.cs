using Microsoft.EntityFrameworkCore;
using Sportshop.Domain.Entities;

namespace Sportshop.Persistence.Context
{
    public class SportshopDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;

        public DbSet<ProductEntity> Products { get; set; } = null!;

        public SportshopDbContext(DbContextOptions<SportshopDbContext> options) : base(options)
        {

        }
    }
}
