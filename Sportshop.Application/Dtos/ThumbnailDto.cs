using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.Dtos
{
    public class ThumbnailDto
    {
        [Required]
        public IFormFile Content { get; set; } = null!;
    }
}
