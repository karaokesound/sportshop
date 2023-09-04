using Microsoft.AspNetCore.Mvc;
using Sportshop.Application.Dtos;

namespace Sportshop.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddProduct(ProductDto requestedProduct)
        {

        }
    }
}
