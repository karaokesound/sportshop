namespace Sportshop.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string City { get; set; } = null!;

        public int Age { get; set; }

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime TokenCreated { get; set; }

        public DateTime TokenExpires { get; set; }

        public ICollection<ProductEntity>? Products { get; set; }
    }
}
