using BookWebApi.Models;

namespace BookWebApi.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string? AuthorName { get; set; }
    }
}
