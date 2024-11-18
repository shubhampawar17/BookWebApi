using BookWebApi.Data;
using BookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Repositories
{
    public class AuthorDetailsRepository : IAuthorDetailRepository
    {
        private readonly BookContext _context;

        public AuthorDetailsRepository(BookContext context)
        {
            _context = context;
        }

        public int Add(AuthorDetails authorDetails)
        {
            _context.AuthorDetails.Add(authorDetails);
            _context.SaveChanges();
            return authorDetails.Id;
        }

        public List<AuthorDetails> GetAll()
        {
            return _context.AuthorDetails.ToList();
        }

        public AuthorDetails Get(int id)
        {
            return _context.AuthorDetails.Find(id);
        }

        public AuthorDetails Update(AuthorDetails authorDetails)
        {
            _context.Entry(authorDetails).State = EntityState.Modified;
            _context.SaveChanges();
            return authorDetails;
        }

        public int Delete(AuthorDetails authorDetails)
        {
            _context.AuthorDetails.Remove(authorDetails);
            _context.SaveChanges();
            return 1;
        }
    }
}
