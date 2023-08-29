namespace Sportshop.API
{
    public class User
    {
        public string Username { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string City { get; set; } = string.Empty;
    }
}
