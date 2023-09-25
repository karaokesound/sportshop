namespace Sportshop.Application.Queries.Product.GetProduct
{
    public class GetProductQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Seller { get; set; } = null!;

        public Guid ThumbnailId { get; set; }
    }
}
