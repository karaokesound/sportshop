using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sportshop.Domain.Entities;

namespace Sportshop.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name);
            builder.Property(p => p.Description);
            builder.Property(p => p.Price);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.Seller);
            builder.Property(p => p.ThumbnailId)
                .HasMaxLength(4);
        }
    }
}
