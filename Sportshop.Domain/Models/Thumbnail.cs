using Microsoft.AspNetCore.Http;

namespace Sportshop.Domain.Models
{
    public class Thumbnail
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public IFormFile Content { get; set; }
    }
}
