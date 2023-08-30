using Sportshop.Domain.Entities;

namespace Sportshop.Application.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUsers();

        Task<UserEntity> GetUser(Guid id);

        Task<UserEntity> GetUserByName(string username);

        Task<bool> CreateUser(UserEntity user);

        Task<bool> UpdateUser(UserEntity user);

        void DeleteUser(Guid id);
    }
}
