using MediatR;
using Sportshop.Application.ReadModels.Dtos.Product;
using Sportshop.Application.ReadModels.Responses;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Seller { get; set; } = null!;

        [Required]
        public ThumbnailDto Thumbnail { get; set; } = null!;
    }
}
