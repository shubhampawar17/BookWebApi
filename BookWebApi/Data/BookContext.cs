using BookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Data
{
    public class BookContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetails> AuthorDetails { get; set; }
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }      
    }
}
