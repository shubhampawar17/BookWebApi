using BookWebApi.Models;

namespace BookWebApi.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book Get(int id);
        int Add(Book book);
        Book Update(Book book);
        int Delete(Book book);

    }
}
