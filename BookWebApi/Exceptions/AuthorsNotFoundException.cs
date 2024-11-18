namespace BookWebApi.Exceptions
{
    public class AuthorsNotFoundException : Exception
    {
        public AuthorsNotFoundException(string message) :base(message) { }
    }
}
