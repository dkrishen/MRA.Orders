using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Repositories
{
    public class BookRepository : RepositoryBase, IBookRepository
    {
        public BookRepository(MeetingRoomAppBooksContext context) : base(context) { }

        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books.ToList();
        }

        public IEnumerable<Book> GetBooksByUser(Guid userId)
        {
            return context.Books.Where(b => b.UserId == userId).ToList();
        }
    }
}
