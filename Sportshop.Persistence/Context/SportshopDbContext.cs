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
                new UserEntity("User1", "City1", 21)
                {
                    FirstName = "Jan",
                    LastName = "Nowak",
                },
                new UserEntity("User2", "City2", 22)
                {
                    FirstName = "Andrzej",
                    LastName = "Kowalski",
                },
                new UserEntity("User3", "City3", 23)
                {
                    FirstName = "Piotr",
                    LastName = "Kowalczyk",
                },
                new UserEntity("User4", "City4", 24)
                {
                    FirstName = "Kamil",
                    LastName = "Grabak",
                },
                new UserEntity("User5", "City5", 25)
                {
                    FirstName = "Leon",
                    LastName = "Ziutkiewicz",
                },
                new UserEntity("User6", "City6", 26)
                {
                    FirstName = "Karol",
                    LastName = "Strasburger",
                },
                new UserEntity("User7", "City7", 27)
                {
                    FirstName = "Andrzej",
                    LastName = "Kipik",
                },
                new UserEntity("User8", "City8", 28)
                {
                    FirstName = "Marzena",
                    LastName = "Bogacz",
                },
                new UserEntity("User9", "City9", 29)
                {
                    FirstName = "Joanna",
                    LastName = "Leśniewska",
                },
                new UserEntity("User10", "City10", 30)
                {
                    FirstName = "Weronika",
                    LastName = "Kalinka",
                },
                new UserEntity("User11", "City11", 31),
                new UserEntity("User12", "City12", 32)
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
