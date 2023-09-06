namespace Sportshop.Domain.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string City { get; set; }

        public int Age { get; set; }

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime TokenCreated { get; set; }

        public DateTime TokenExpires { get; set; }

        public ICollection<ProductModel>? Products { get; set; }

        public UserModel(string username, string city)
        {
            Id = Guid.NewGuid();
            Username = username;
            City = city;

            Products = new List<ProductModel>();
        }
    }
}
