using AutoMapper;
using BookWebApi.DTOs;
using BookWebApi.Exceptions;
using BookWebApi.Models;
using BookWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> authorRepository , IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        ////1.Find Author by Name
        //public Author GetAuthorByName(string name)
        //{
        //    return _mapper.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        //}
        ////4.Find Author of a particular Book
        //public Author GetAuthorByBookId(int bookId)
        //{
        //    var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
        //    return book != null ? _context.Authors.FirstOrDefault(a => a.Id == book.AuthorId) : null;
        //}

        public int AddAuthor(AuthorDto authorDto)
        {
            Author author = _mapper.Map<Author>(authorDto);
            _authorRepository.Add(author);
            return author.Id;
        }
        public bool DeleteAuthor(int id)
        {
            var existingAuthor = _authorRepository.GetById(id);
            if (existingAuthor == null)
            {
                _authorRepository.Delete(existingAuthor);
                return true;
            }
            throw new AuthorNotFoundException($"No Author found {id}");
        }

        public AuthorDto FindAuthorByName(string name)
        {
            var author = _authorRepository.GetAll().Include(a => a.AuthorDetails).Include(a => a.Books)
                .FirstOrDefault(a => a.Name == name);
            if (author == null)
            {
                throw new AuthorNotFoundException($"No author found with the name '{name}'");
            }
            return _mapper.Map<AuthorDto>(author);
        }

        //public Author GetAuthor(int id)
        //{
        //    return _authorRepository.GetById(id);
        //}

        //public List<Author> GetAuthors()
        //{
        //    var authors = _authorRepository.GetAll().Include(a=>a.Books).Include(a=>a.AuthorDetails).ToList();
        //    List<AuthorDto> authorDtos = _mapper.Map<List<AuthorDto>>(authors);
        //    return _authorRepository.GetAll().Include(a=>a.Books).Include(a=>a.AuthorDetails).ToList();
        //}
        //public Author UpdateAuthor(Author author)
        //{
        //    var existingAuthor = _authorRepository.GetAll().AsNoTracking().FirstOrDefault(author => author.Id == author.Id);       
        //    if (existingAuthor == null)
        //    {
        //        _authorRepository.Update(author);
        //        return author;
        //    }
        //    return existingAuthor;
        //}

        //public Author UpdateAuthor(Author author)
        //{
        //    var existingAuthor = _authorRepository.GetAll().AsNoTracking().FirstOrDefault(author => author.Id == author.Id);
        //    if (existingAuthor == null)
        //    {
        //        _authorRepository.Update(author);
        //        return author;
        //    }
        //    return existingAuthor;
        //}

        public AuthorDto UpdateAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            var existingAuthor = _authorRepository.GetAll().Include(a => a.Books).Include(a => a.AuthorDetails).AsNoTracking()
                .FirstOrDefault(a => a.Id == author.Id);
            if (existingAuthor == null)
            {
                throw new AuthorNotFoundException($"No author found with id-> {author.Id}");
            }
            _authorRepository.Update(author);
            return authorDto;
        }

        public AuthorDto GetAuthor(int id)
        {
            var author = _authorRepository.GetAll().Include(a => a.AuthorDetails).Include(a => a.Books).FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                throw new AuthorNotFoundException($"No author found with id-> {id}");
            }
            return _mapper.Map<AuthorDto>(author);
        }

        List<AuthorDto> IAuthorService.GetAuthors()
        {
            var authors = _authorRepository.GetAll().Include(a => a.AuthorDetails).Include(a => a.Books).ToList();
            if (!authors.Any())
            {
                throw new AuthorNotFoundException("No authors found do add authors please");
            }
            return _mapper.Map<List<AuthorDto>>(authors);
        }

        //Author IAuthorService.DeleteAuthor(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IAuthorService.UpdateAuthor(Author author)
        //{
        //    throw new NotImplementedException();
        //}
    }
    }