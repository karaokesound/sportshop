using Sportshop.API;
using Sportshop.Domain.Entities;

namespace Sportshop.Application.Services.Authentication
{
    public interface IJwtService
    {
        string GenerateToken(UserEntity user);

        TokenModel GenerateRefreshToken(UserEntity user, string token);
    }
}
