namespace Sportshop.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Seller { get; set; }

        public Thumbnail Thumbnail { get; set; }
    }
}
