using Microsoft.EntityFrameworkCore;
using Serilog;
using Sportshop.Domain.Entities;
using Sportshop.Persistence.Context;
using System.Text.Json;

namespace Sportshop.Persistence
{
    public class DbSeeder
    {
        private class JsonProductDto
        {
            public string Name { get; set; } = null!;
            public string Description { get; set; } = null!;
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string Brand { get; set; } = null!;
            public string Category { get; set; } = null!;
        }

        private readonly static ILogger _logger = Log.ForContext(typeof(DbSeeder));

        public async static Task Seed(SportshopDbContext context)
        {
            // context.Database.EnsureCreated() does not use migrations to create the database and therefore the
            // database that is created cannot be later updated using migrations, use context.Database.Migrate()
            // instead
            context.Database.Migrate();

            if (context.Products.Any())
            {
                return;
            }

            var products = await GetDefaultProducts();

            await context.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }

        public async static Task<List<ProductEntity>> GetDefaultProducts()
        {
            var productsEntitiesList = new List<ProductEntity>();

            try
            {
                using FileStream stream = File.OpenRead(@"C:\Users\karao\source\repos\sportshop\Sportshop.Persistence\products.json");
                var productsList = await JsonSerializer.DeserializeAsync<List<JsonProductDto>>(stream);

                foreach (var product in productsList)
                {
                    var productEntity = new ProductEntity()
                    {
                        Id = Guid.NewGuid(),
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        Brand = product.Brand,
                        Category = product.Category,
                        ThumbnailId = Guid.NewGuid()

                    };

                    productsEntitiesList.Add(productEntity);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error occurred in DbSeeder.cs class while seeding the database", ex.Message);
            }

            return productsEntitiesList;
        }
    }
}
