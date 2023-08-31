namespace Sportshop.Domain.Models
{
    public class User
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

        public User(string username, string city)
        {
            Id = Guid.NewGuid();
            Username = username;
            City = city;
        }
    }
}
