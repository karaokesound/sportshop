using Sportshop.Domain.Entities;

namespace Sportshop.API
{
    public class TokenModel
    {
        public string Token { get; set; } = null!;

        public string RefreshToken { get; set; } = null!;

        public DateTime RefreshTokenCreated { get; set; } = DateTime.Now;

        public DateTime RefreshTokenExpires { get; set; }

        public UserEntity? User { get; set; }
    }
}
