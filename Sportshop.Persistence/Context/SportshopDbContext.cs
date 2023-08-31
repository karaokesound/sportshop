using Microsoft.EntityFrameworkCore;
using Sportshop.Domain.Entities;

namespace Sportshop.Persistence.Context
{
    public class SportshopDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;

        public SportshopDbContext(DbContextOptions<SportshopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasData(
                new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Username = "User1",
                    City = "City1",
                    FirstName = "Jan",
                    LastName = "Nowak",
                },
                new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Username = "User2",
                    City = "City2",
                    FirstName = "Andrzej",
                    LastName = "Kowalski",
                },
                new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Username = "User3",
                    City = "City3",
                    FirstName = "Piotr",
                    LastName = "Kowalczyk",
                },
                new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Username = "User4",
                    City = "City4",
                    FirstName = "Kamil",
                    LastName = "Grabak",
                },
                new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Username = "User5",
                    City = "City5",
                    FirstName = "Leon",
                    LastName = "Ziutkiewicz",
                },
                new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Username = "User6",
                    City = "City6"
                },
                new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Username = "User7",
                    City = "City7"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
