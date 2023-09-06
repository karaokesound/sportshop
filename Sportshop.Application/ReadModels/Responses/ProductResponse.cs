namespace Sportshop.Application.ReadModels.Responses
{
    public class ProductResponse
    {
        public string Message { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Seller { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
