using Domain.DTO;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Services.Contracts
{
    public interface IBookService
    {
        Book Get(int bookId);

        IEnumerable<Book> GetAllBooksOnDefaultSorting();
        void Purchase(BookStockMovement stockMovement);
        void Sell(BookStockMovement stockMovement);
        void ChangePrice(ItemPrice itemPrice);

        Book Add(Book newBook);

        Book Remove(Book book);
        Book Remove(int id);

        Book Update(Book newBook);
    }
}
