using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sportshop.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SampleController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> GetUsers()
        {
            return Ok("User1");
        }
    }
}
