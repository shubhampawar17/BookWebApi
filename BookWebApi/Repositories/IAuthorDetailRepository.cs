using BookWebApi.Models;

namespace BookWebApi.Repositories
{
    public interface IAuthorDetailRepository
    {
        List<AuthorDetails> GetAll();
        AuthorDetails Get(int id);
        int Add(AuthorDetails authorDetails);
        AuthorDetails Update(AuthorDetails authorDetails);
        int Delete(AuthorDetails authorDetails);
    }
}
