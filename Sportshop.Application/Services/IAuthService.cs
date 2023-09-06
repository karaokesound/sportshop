using Sportshop.Application.ReadModels.Dtos.Authentication;
using Sportshop.Domain.Entities;

namespace Sportshop.Application.Services
{
    public interface IAuthService
    {
        Task CreateUser(UserDto requestedUser, byte[] passwordHash, byte[] passwordSalt);

        string GenerateToken(UserEntity user);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        Task<bool> UserDataValidation(UserDto requestedUser, int operationValue);
    }
}
