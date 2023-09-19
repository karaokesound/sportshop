using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sportshop.Application.Commands.Users.Register;
using Sportshop.Application.Queries.Users.GetUsers;

namespace Sportshop.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
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

            return result != null ? Ok(result) : NotFound();
        }
    }
}
