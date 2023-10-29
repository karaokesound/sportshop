namespace Sportshop.Application.Queries.Product.GetProduct
{
    public class GetProductQueryResponse
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Seller { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
