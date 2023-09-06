using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Domain.Models
{
    public class ThumbnailModel
    {
        [MaxLength(4)]
        public Guid Id { get; set; }

        public string FileName { get; set; } = null!;

        public IFormFile Content { get; set; } = null!;
    }
}
