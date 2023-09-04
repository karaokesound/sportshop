using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Sportshop.Application.Dtos.User;
using Sportshop.Application.Repositories;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Sportshop.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task CreateUser(UserDto requestedUser, byte[] passwordHash, byte[] passwordSalt)
        {
            var user = _mapper.Map<User>(requestedUser);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Mapping to entity model
            var mappedUser = _mapper.Map<UserEntity>(user);

            await _userRepository.CreateUserAsync(mappedUser);
            await _userRepository.SaveChangesAsync();
        }

        public string GenerateToken(UserEntity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("given_name", user.Username.ToString()),
                new Claim("city", user.City.ToString()),
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn;
        }

        public RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Created = DateTime.Now,
                Expires = DateTime.Now.AddDays(7)
            };

            return refreshToken;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserDataValidation(UserDto requestedUser, int operationValue)
        {
            switch (operationValue)
            {
                case 0: // Registration
                    bool usernameExists = await _userRepository.GetUserByNameAsync(requestedUser.Username) != null ? true : false;

                    if (usernameExists) return false;
                    break;

                case 1: // Login
                    var dbUser = await _userRepository.GetUserByNameAsync(requestedUser.Username);
                    bool passwordValidation = false;

                    if (dbUser != null)
                    {
                        var hmac = new HMACSHA512(dbUser.PasswordSalt!);
                        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(requestedUser.Password));

                        passwordValidation = computedHash.SequenceEqual(dbUser.PasswordHash!);
                    }

                    if (dbUser == null || !passwordValidation) return false;
                    break;
            }

            return true;
        }
    }
}
