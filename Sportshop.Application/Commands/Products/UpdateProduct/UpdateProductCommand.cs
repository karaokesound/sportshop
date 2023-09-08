using MediatR;
using Sportshop.Application.Dtos.Product;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        [Required]
        public Guid Id { get; set; }

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
        public ThumbnailDto Thumbnail { get; set; }
    }
}
