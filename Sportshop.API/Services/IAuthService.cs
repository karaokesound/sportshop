using Sportshop.Application.Dtos;
using Sportshop.Domain.Entities;

namespace Sportshop.API.Services
{
    public interface IAuthService
    {
        Task CreateUser(UserDto requestedUser, byte[] passwordHash, byte[] passwordSalt);

        string GenerateToken(UserEntity user);

        RefreshToken GenerateRefreshToken();

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        Task<bool> UserDataValidation(UserDto requestedUser, int operationValue);
    }
}
