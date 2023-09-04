using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.Dtos.Product
{
    public class ThumbnailDto
    {
        [Required]
        public IFormFile Content { get; set; } = null!;
    }
}
