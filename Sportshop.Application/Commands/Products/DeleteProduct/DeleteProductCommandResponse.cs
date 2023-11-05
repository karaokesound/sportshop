namespace Sportshop.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandResponse
    {
        public string Message { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Seller { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
