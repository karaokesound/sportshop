using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Domain.Models
{
    public class Thumbnail
    {
        [MaxLength(4)]
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public IFormFile Content { get; set; }
    }
}
