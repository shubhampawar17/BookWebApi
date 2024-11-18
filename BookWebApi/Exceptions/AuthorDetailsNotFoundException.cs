namespace BookWebApi.Exceptions
{
    public class AuthorDetailsNotFoundException : Exception
    {
        public AuthorDetailsNotFoundException(string message): base(message) { }
    }
}
