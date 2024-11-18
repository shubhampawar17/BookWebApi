namespace BookWebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime DateOfRelease { get; set; }
        //many to one relationship 
        public Author? Author { get; set; }
    }
}
