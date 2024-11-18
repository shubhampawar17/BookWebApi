using BookWebApi.DTOs;
using BookWebApi.Models;

namespace BookWebApi.Service
{
    public interface IBookService
    {
        public List<BookDto> GetAllBooks();
        public BookDto GetBookById(int id);
        public int AddBook(BookDto bookDto);
        public BookDto UpdateBook(BookDto bookDto);
        public bool DeleteBook(int id);
        public List<BookDto> FindBookByAuthorId(int authorId);
        public AuthorDto FindAuthorByBookId(int bookId);
    }
}
