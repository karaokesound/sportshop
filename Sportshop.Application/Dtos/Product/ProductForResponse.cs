namespace Sportshop.Application.Dtos.Product
{
    public class ProductForResponse
    {
        public string Message { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Seller { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
