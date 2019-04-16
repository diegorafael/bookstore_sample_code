using Domain.DTO;
using Domain.Entities;
using Domain.EventArgs;
using Domain.Repository;
using Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class BookService : IBookService
    {
        protected IBookRepository bookRepository;
        public EventHandler<StockMovementEventArgs> BookSelled;
        public EventHandler<StockMovementEventArgs> BookPurchased;
        public EventHandler<BookPriceChangeEventArgs> PriceChanged;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Book Get(int bookId)
        {
            return bookRepository.Get(bookId);
        }

        public IEnumerable<Book> GetAllBooksOnDefaultSorting()
        {
            var results = bookRepository
                .GetAll()
                .OrderBy(b => b.Name);

            return results;
        }

        public Book Add(Book item)
        {
            var addedBook = bookRepository.Add(item);
            bookRepository.SaveChanges();

            return addedBook;
        }
        public void Purchase(BookStockMovement stockMoviment)
        {
            var book = bookRepository.Get(stockMoviment.BookId);
            OnPurchasingBook(new StockMovementEventArgs(book, stockMoviment));
            book.IncreaseStock(stockMoviment.IncommingUnits);
            bookRepository.SaveChanges();
        }
        public void ChangePrice(ItemPrice itemPrice)
        {
            var book = bookRepository.Get(itemPrice.Id);
            OnPriceChanging(new BookPriceChangeEventArgs(book, itemPrice.Price));
            book.Price = itemPrice.Price;
            bookRepository.SaveChanges();
        }

        private void OnPriceChanging(BookPriceChangeEventArgs bookPriceChangeEventArgs)
        {
            PriceChanged?.Invoke(this, bookPriceChangeEventArgs);
        }

        public void Sell(BookStockMovement stockMoviment)
        {
            var book = bookRepository.Get(stockMoviment.BookId);
            OnSellingBook(new StockMovementEventArgs(book, stockMoviment));
            book.DecreaseStock(stockMoviment.IncommingUnits);
            bookRepository.SaveChanges();
        }

        public Book Remove(Book item)
        {
            var removedBook = bookRepository.Remove(item);
            bookRepository.SaveChanges();

            return removedBook;
        }
        public Book Remove(int id)
        {
            var book = bookRepository.Get(id);
            return Remove(book);
        }

        public Book Update(Book newBook)
        {
            var oldBook = bookRepository.Get(newBook.Id);
            oldBook.Name = newBook.Name;
            oldBook.PublishingDate = newBook.PublishingDate;
            oldBook.Category = newBook.Category;
            bookRepository.Update(oldBook);
            bookRepository.SaveChanges();

            return oldBook;
        }

        protected virtual void OnSellingBook(StockMovementEventArgs stockMovement)
        {
            BookSelled?.Invoke(this, stockMovement);
        }

        protected virtual void OnPurchasingBook(StockMovementEventArgs stockMovement)
        {
            BookPurchased?.Invoke(this, stockMovement);
        }
    }
}
