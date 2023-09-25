using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sportshop.API;
using Sportshop.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Sportshop.Application.Services.Authentication
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToken(UserEntity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                _configuration["Authentication:SecretForKey"]));

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

        public TokenModel GenerateRefreshToken(UserEntity user, string token)
        {
            var tokenModel = new TokenModel()
            {
                RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                RefreshTokenCreated = DateTime.Now,
                RefreshTokenExpires = DateTime.Now.AddDays(7),
                Token = token,
                User = user,
            };

            tokenModel.User.RefreshToken = tokenModel.RefreshToken;
            tokenModel.User.TokenCreated = tokenModel.RefreshTokenCreated;
            tokenModel.User.TokenExpires = tokenModel.RefreshTokenExpires;

            return tokenModel;
        }

        public void SetRefreshToken(TokenModel token)
        {
            var response = _httpContextAccessor.HttpContext!.Response;

            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = token.RefreshTokenExpires,
            };

            response.Cookies.Append("refreshToken", token.RefreshToken, cookieOptions);
        }
    }
}
