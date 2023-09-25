using MediatR;
using Sportshop.Application.Dtos.Product;

namespace Sportshop.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Seller { get; set; } = null!;

        public ThumbnailDto Thumbnail { get; set; } = null!;
    }
}
