using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sportshop.Application.Commands.Users.Register;
using Sportshop.Application.Queries.Users.GetUsers;
using ILogger = Serilog.ILogger;

namespace Sportshop.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public UsersController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<ActionResult> GetUsers()
        {
            var query = new GetUsersQuery();
            var result = await _mediator.Send(query);

            _logger.Information("My THIRD log => {@result}", result);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
