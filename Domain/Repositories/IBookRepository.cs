using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Repository
{
    public interface IBookRepository
    {
        Book Get(int bookId);
        Book Get(Book book);
        IEnumerable<Book> GetAll();
        Book Remove(Book item);
        Book Add(Book item);
        Book Update(Book oldBook);
        void SaveChanges();
    }
}
