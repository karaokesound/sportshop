using Sportshop.Domain.Entities;
using Sportshop.Persistence.Context;

namespace Sportshop.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SportshopDbContext _context;

        public UserRepository(SportshopDbContext context)
        {
            _context = context;
        }

        public Task<UserEntity> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetUserByName(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
