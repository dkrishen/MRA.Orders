using BookApi.Models;
using System;
using System.Collections.Generic;

namespace BookApi.Repositories
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetBooks();
        public IEnumerable<Book> GetBooksByUser(Guid userId);
        public void AddBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(Guid id);
    }
}
