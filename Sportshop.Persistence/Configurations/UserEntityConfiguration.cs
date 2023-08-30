using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sportshop.Persistence.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Username);
            builder.Property(u => u.FirstName);
            builder.Property(u => u.LastName);
            builder.Property(u => u.City);
            builder.Property(u => u.Age);
            
            builder.Property(u => u.PasswordHash);
            builder.Property(u => u.PasswordSalt);
            builder.Property(u => u.RefreshToken);
            builder.Property(u => u.TokenCreated);
            builder.Property(u => u.TokenExpires);
        }
    }
}
