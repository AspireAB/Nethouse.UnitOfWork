using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nethouse.UnitOfWork;

namespace Nethouse.UnitOfWork.BookDomain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var uow = new TestUnitOfWork();
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

            var result = bookRepo.GetBooksWithMinimumPageCount(600);
            Assert.AreEqual(1, result.Count);
        }
    }
}

