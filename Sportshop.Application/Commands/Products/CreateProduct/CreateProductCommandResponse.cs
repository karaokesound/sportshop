namespace Sportshop.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public string Message { get; set; } = null!;

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Seller { get; set; } = null!;

        public string Quantity { get; set; } = null!;
    }
}
