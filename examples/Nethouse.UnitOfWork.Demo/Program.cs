using System;
using System.Linq;
using Nethouse.UnitOfWork.BookDomain;

namespace Nethouse.UnitOfWork.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new BooksContext())
            {
                //inject the EF Book context into the BookRepository
                var bookRepo = new BookRepository(uow);

                //add some books to the repository
                var smallBook = new Book()
                {
                    Title = "This is a small book",
                    PageCout = 70,
                    Description = "Lorem ipsum pirum parum",
                };
                bookRepo.Add(smallBook);

                var bigBook = new Book()
                {
                    Title = "This is a big book",
                    PageCout = 1235,
                    Description = "Foo Bar Baz",
                };
                bookRepo.Add(bigBook);
                uow.SaveChanges();

                //fetch entities using the repository:
                var booksWith600Pages = bookRepo.GetBooksWithMinimumPageCount(600);
                foreach (var book in booksWith600Pages)
                {
                    Console.WriteLine("The book {0} has {1} pages",book.Title,book.PageCout);
                }

                Console.ReadLine();
            }
        }
    }    
}
