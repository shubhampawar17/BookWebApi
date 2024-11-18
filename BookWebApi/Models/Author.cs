using System.ComponentModel.DataAnnotations;

namespace BookWebApi.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //one to many relationship
        public List<Book>? Books { get; set; }
        //one to one relationship
        public AuthorDetails? AuthorDetails { get; set; }
        
    }
}
