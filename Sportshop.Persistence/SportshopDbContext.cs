using Microsoft.EntityFrameworkCore;

namespace Sportshop.Persistence
{
    public class SportshopDbContext : DbContext
    {
        public SportshopDbContext(DbContextOptions<SportshopDbContext> options) : base(options)
        {
            
        }
    }
}
