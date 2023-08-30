using Sportshop.Domain.Entities;

namespace Sportshop.Application.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetUsersAsync();

        Task<UserEntity> GetUserAsync(Guid id);

        Task<UserEntity> GetUserByNameAsync(string username);

        Task CreateUserAsync(UserEntity user);

        void DeleteUser(Guid id);

        Task<bool> SaveChangesAsync();
    }
}
