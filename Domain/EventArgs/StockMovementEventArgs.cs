using Domain.DTO;
using Domain.Entities;

namespace Domain.EventArgs
{
    public class StockMovementEventArgs
    {
        public Book Book { get; }
        public BookStockMovement StockMovement { get;  }

        public StockMovementEventArgs(Book book, BookStockMovement stockMovement)
        {
            Book = book;
            StockMovement = stockMovement;
        }
    }
}
