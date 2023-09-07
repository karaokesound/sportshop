using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sportshop.Application.Commands.Authentication.CreateUser;
using Sportshop.Application.Commands.Authentication.LoginUser;
using Sportshop.Application.Commands.Authentication.RefreshToken;
using Sportshop.Domain.Models;

namespace Sportshop.API.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserCommand command)
        {
            TokenModel result = await _mediator.Send(command);

            SetRefreshToken(result);

            return Ok(result.Token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var result = await _mediator.Send(command);

            SetRefreshToken(result);

            return Ok(result.RefreshToken);
        }

        private void SetRefreshToken(TokenModel tokenModel)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = tokenModel.RefreshTokenExpires,
            };

            Response.Cookies.Append("refreshToken", tokenModel.RefreshToken, cookieOptions);
        }
    }
}
