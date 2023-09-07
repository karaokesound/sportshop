using Microsoft.AspNetCore.Http;

namespace Sportshop.Application.Dtos.Product
{
    public class ThumbnailDto
    {
        public IFormFile Content { get; set; } = null!;
    }
}
