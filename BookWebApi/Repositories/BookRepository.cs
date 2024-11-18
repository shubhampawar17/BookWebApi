using BookWebApi.Data;
using BookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public int Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book Get(int id)
        {
            return _context.Books.Find(id);
        }

        public Book Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
            return book;
        }

        public int Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
            return 1;
        }
    }
}
