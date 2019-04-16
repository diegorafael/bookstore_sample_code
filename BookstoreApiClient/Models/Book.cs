using System;

namespace BookstoreApiClient.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishingDate { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
