﻿namespace Sportshop.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Seller { get; set; } = null!;

        public int ThumbnailId { get; set; }

        public User? User { get; set; }
    }
}
