using Microsoft.EntityFrameworkCore;
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

        public async Task<List<UserEntity>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUserAsync(Guid id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) throw new Exception("This user doesn't exist in the database");

            return user;
        }

        public async Task<UserEntity> GetUserByNameAsync(string username)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) throw new Exception("This user doesn't exist in the database");

            return user;
        }

        public async Task CreateUserAsync(UserEntity user)
        {
            await _context.Users.AddAsync(
                new UserEntity(user.Username, user.City, user.Age)
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PasswordHash = user.PasswordHash,
                    PasswordSalt = user.PasswordSalt,
                    RefreshToken = user.RefreshToken,
                    TokenCreated = user.TokenCreated,
                    TokenExpires = user.TokenExpires,
                });
        }

        public void DeleteUser(Guid id)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Id == id);

            if (user == null) throw new Exception("This user doesn't exist in the database");

            _context.Users.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
