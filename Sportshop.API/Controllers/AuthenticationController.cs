using Microsoft.AspNetCore.Mvc;
using Sportshop.API.Services;
using Sportshop.Application.Dtos;
using Sportshop.Application.Repositories;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;

namespace Sportshop.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _service;

        private readonly IUserRepository _userRepository;

        public AuthenticationController(IAuthService service, IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto requestedUser)
        {
            if (!await _service.UserDataValidation(requestedUser, 0)) return BadRequest("This username already exists. Try with another one!");

           _service.CreatePasswordHash(requestedUser.Password, out byte[] passwordHash, out byte[] passwordSalt);

            await _service.CreateUser(requestedUser, passwordHash, passwordSalt);

            return Ok("User succesfully created!");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto requestedUser)
        {
            if (!await _service.UserDataValidation(requestedUser, 1)) return BadRequest("User or password is not valid. Check if you've entered correct username and password.");

            var user = await _userRepository.GetUserByNameAsync(requestedUser.Username);

            string userToken = _service.GenerateToken(user);
            RefreshToken userRefreshToken = _service.GenerateRefreshToken();

            SetRefreshToken(userRefreshToken, user);

            return Ok(userToken);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var user = await _userRepository.GetUserByRefreshToken(refreshToken!);

            if (user == null
                ||!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Something gone wrong! Make sure you've entered valid login data. If so, it seems your refresh token is invalid.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Your token expired.");
            }

            string userToken = _service.GenerateToken(user);

            var newUserRefreshToken = _service.GenerateRefreshToken();
            SetRefreshToken(newUserRefreshToken, user);

            return Ok(userToken);
        }

        private void SetRefreshToken(RefreshToken newRefreshToken, UserEntity user)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires,

            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;

            _userRepository.SaveChangesAsync();
        }
    }
}
