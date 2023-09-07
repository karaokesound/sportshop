using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("get")]
        public async Task<ActionResult> GetUsers()
        {
            var query = new GetUsersQuery();
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
