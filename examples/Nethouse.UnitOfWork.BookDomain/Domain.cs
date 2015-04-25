using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Nethouse.UnitOfWork.BookDomain
{
    public class BooksContext : DbContext, IUnitOfWork
    {
        public DbSet<Book> Books { get; set; }
    }

    public class BookRepository : Repository<Book>
    {
        public BookRepository(IUnitOfWork uow)
            : base(uow)
        {
        }

        public IEnumerable<Book> GetBooksWithMinimumPageCount(int minimumPageCount)
        {
            return Items.Where(book => book.PageCout >= minimumPageCount).ToList().AsReadOnly();
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCout { get; set; }
    }
}