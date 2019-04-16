using System.Collections.Generic;
using System.Linq;
using CrossCutting;
using DataPersistence.Contexts;
using DataPersistence.Contracts;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataPersistence.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(IBookstoreContext context) 
            : base(context)
        {
        }

        public Book Get(int bookId)
        {
            return base.GetSingleOrDefaultByExpression(b =>  b.Id == bookId);
        }
        public Book Get(Book book)
        {
            return Get(book.Id);
        }

        public IEnumerable<Book> GetAll()
        {
            return Context.Set<Book>();
        }
    }
}
