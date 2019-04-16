using Domain.DTO;
using Domain.Entities;

namespace Domain.EventArgs
{
    public class BookPriceChangeEventArgs
    {
        public Book Book { get; }
        public decimal Price { get;  }

        public BookPriceChangeEventArgs(Book book, decimal price)
        {
            Book = book;
            Price = price;
        }
    }
}
