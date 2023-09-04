using Sportshop.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.Dtos
{
    
    public class ProductDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Seller { get; set; } = null!;

        [Required]
        public Thumbnail Thumbnail { get; set; } = null!;
    }
}
