using BookWebApi.Data;
using BookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookContext _context;

        public AuthorRepository(BookContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            return _context.Authors.Include(a => a.Books).Include(a => a.Name).ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.Include(a => a.Books).Include(a => a.Name)
                                   .FirstOrDefault(a => a.Id == id);
        }

        public int Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author.Id;
        }

        public bool Update(Author author)
        {
            var existingAuthor = _context.Authors.Find(author.Id);
            if (existingAuthor == null) return false;

            _context.Entry(existingAuthor).CurrentValues.SetValues(author);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null) return false;

            _context.Authors.Remove(author);
            _context.SaveChanges();
            return true;
        }

    }
}