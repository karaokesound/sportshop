using MediatR;
using Sportshop.Application.Dtos.Product;

namespace Sportshop.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Seller { get; set; } = null!;

        public ThumbnailDto Thumbnail { get; set; } = null!;
    }
}
