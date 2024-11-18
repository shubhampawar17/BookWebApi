namespace BookWebApi.Models
{
    public class AuthorDetails
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int? AuthorId { get; set; }
        //one to one relationship
        public Author? Author { get; set; }
    }
}
