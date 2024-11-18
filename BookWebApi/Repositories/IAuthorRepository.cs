using BookWebApi.Models;

namespace BookWebApi.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author GetById(int id);
        int Add(Author author);
        bool Update(Author author);
        bool Delete(int id);
    }
}
