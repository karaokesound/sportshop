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
            var result = await _mediator.Send(command);

            return Ok($"{result.Message}\nAccess Token:\n{result.TokenModel.Token}" +
                $"\nRefresh token:\n{result.TokenModel.RefreshToken}");
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok($"{result.Message}\n{result.TokenModel.RefreshToken}");
        }
    }
}
