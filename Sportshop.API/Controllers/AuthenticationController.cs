using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sportshop.Application.Commands.Authentication.Login;
using Sportshop.Application.Commands.Authentication.RefreshToken;

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

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginCommand command)
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
