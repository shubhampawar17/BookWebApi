using BookWebApi.DTOs;
using BookWebApi.Models;

namespace BookWebApi.Service
{
    public interface IAuthorDetailService
    {
        public List<AuthorDetailsDto> GetAllAuthorDetails();
        public AuthorDetailsDto GetAuthorDetails(int id);
        public int AddAuthorDetails(AuthorDetailsDto authorDetails);
        public AuthorDetailsDto UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto);
        public bool DeleteAuthorDetails(int id);
        public AuthorDetailsDto FindAuthorDetailsByAuthorId(int id);    
    }
}
