using MediatR;
using Sportshop.API;
using Sportshop.Application.Repositories;
using Sportshop.Application.Services.Authentication;
using System.Security.Cryptography;

namespace Sportshop.Application.Commands.Authentication.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, TokenModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<TokenModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (!await UserDataValidation(request)) return null!;

            var userEntity = await _userRepository.GetUserByNameAsync(request.Username);

            string userToken = _jwtService.GenerateToken(userEntity);
            TokenModel newUserRefreshToken = _jwtService.GenerateRefreshToken(userEntity, userToken);

            await _userRepository.SaveChangesAsync();

            return newUserRefreshToken;
        }

        //private string GenerateToken(UserEntity user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
        //        _configuration["Authentication:SecretForKey"]));

        //    var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claimsForToken = new List<Claim>
        //    {
        //        new Claim("given_name", user.Username.ToString()),
        //        new Claim("city", user.City.ToString()),
        //    };

        //    var jwtSecurityToken = new JwtSecurityToken(
        //        _configuration["Authentication:Issuer"],
        //        _configuration["Authentication:Audience"],
        //        claimsForToken,
        //        DateTime.UtcNow,
        //        DateTime.UtcNow.AddHours(1),
        //        signingCredentials);

        //    var tokenToReturn = new JwtSecurityTokenHandler()
        //        .WriteToken(jwtSecurityToken);

        //    return tokenToReturn;
        //}

        //private TokenModel GenerateRefreshToken(UserEntity user, string token)
        //{
        //    var tokenModel = new TokenModel()
        //    {
        //        RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
        //        RefreshTokenCreated = DateTime.Now,
        //        RefreshTokenExpires = DateTime.Now.AddDays(7),
        //        Token = token,
        //        User = user,
        //    };

        //    tokenModel.User.RefreshToken = tokenModel.RefreshToken;
        //    tokenModel.User.TokenCreated = tokenModel.RefreshTokenCreated;
        //    tokenModel.User.TokenExpires = tokenModel.RefreshTokenExpires;

        //    return tokenModel;
        //}

        private async Task<bool> UserDataValidation(LoginCommand requestedUser)
        {
            var dbUser = await _userRepository.GetUserByNameAsync(requestedUser.Username);
            bool passwordValidation = false;

            if (dbUser != null)
            {
                var hmac = new HMACSHA512(dbUser.PasswordSalt!);
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(requestedUser.Password));

                passwordValidation = computedHash.SequenceEqual(dbUser.PasswordHash!);
            }

            if (dbUser == null || !passwordValidation) return false;

            return true;
        }
    }
}
