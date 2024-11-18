using BookWebApi.DTOs;
using BookWebApi.Models;

namespace BookWebApi.Service
{
    public interface IAuthorService
    {
        public List<AuthorDto> GetAuthors();
        public AuthorDto GetAuthor(int id);
        public int AddAuthor(AuthorDto authorDto);
        public AuthorDto UpdateAuthor(AuthorDto authorDto);
        public bool DeleteAuthor(int id);
        public AuthorDto FindAuthorByName(string name);
    }
}
