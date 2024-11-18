using AutoMapper;
using BookWebApi.DTOs;
using BookWebApi.Exceptions;
using BookWebApi.Models;
using BookWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        ////3.Find Book of a particular Author
        //public IEnumerable<Book> GetBooksByAuthor(int authorId)
        //{
        //    return _context.Books.Where(b => b.AuthorId == authorId).ToList();
        //}

        public List<BookDto> GetAllBooks()
        {
            var books = _bookRepository.GetAll().Include(b => b.Author).ToList();
            if (!books.Any())
            {
                throw new BookNotFoundException("No books found");
            }
            return _mapper.Map<List<BookDto>>(books);
        }

        public BookDto GetBookById(int id)
        {
            var book = _bookRepository.GetAll().Include(b => b.Author).FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                return _mapper.Map<BookDto>(book);
            }
            throw new BookNotFoundException($"No book found with id-> {id}");
        }

        public int AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.Add(book);
            return book.Id;
        }

        //public bool UpdateBook(BookDto bookDto)
        //{
        //    var existingBook = _bookRepository.Get(bookDto.Id);
        //    if (existingBook != null)
        //    {
        //        _mapper.Map(bookDto, existingBook);
        //        _bookRepository.Update(existingBook);
        //        return true;
        //    }
        //    return false;
        //}

        public bool DeleteBook(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book != null)
            {
                _bookRepository.Delete(book);
                return true;
            }
            throw new BookNotFoundException($"No Book Found {id}");
        }

        public BookDto UpdateBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var existingBook = _bookRepository.GetAll().Include(b => b.Author).AsNoTracking().FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
            {
                throw new BookNotFoundException($"No book found with id-> {book.Id}");
            }
            _bookRepository.Update(book);
            return bookDto;
        }

        public List<BookDto> FindBookByAuthorId(int authorId)
        {
            var books = _bookRepository.GetAll().Include(b => b.Author).Where(b => b.AuthorId == authorId).ToList();
            if (!books.Any())
            {
                throw new BookNotFoundException($"No books found for author id-> {authorId}");
            }
            return _mapper.Map<List<BookDto>>(books);
        }

        public AuthorDto FindAuthorByBookId(int bookId)
        {
            var book = _bookRepository.GetAll().Include(b => b.Author).FirstOrDefault(b => b.Id == bookId);
            if (book == null || book.Author == null)
            {
                throw new BookNotFoundException($"No book found with id-> {bookId}");
            }
            var author = book.Author;
            author.Books = _bookRepository.GetAll().Where(b => b.AuthorId == author.Id).ToList();

            return _mapper.Map<AuthorDto>(author);
        }
    }
    }

    //public class BookService : IBookService
    //{

    //private readonly IRepository<Book> _bookRepository;

    //public BookService(IRepository<Book> bookRepository)
    //{
    //    _bookRepository = bookRepository;
    //}

    //public List<Book> GetAllBooks()
    //{
    //    var query = _bookRepository.GetAll();
    //    var list = query.ToList();
    //    return list;
    //}

    //public Book GetBookById(int id)
    //{
    //    return _bookRepository.GetById(id);
    //}

    //public int AddBook(Book book)
    //{
    //    return _bookRepository.Add(book);
    //}

    //public bool UpdateBook(Book book)
    //{
    //    var existingBook = _bookRepository.GetById(book.Id);
    //    if (existingBook != null)
    //    {
    //        _bookRepository.Update(book);
    //        return true;
    //    }
    //    return false;
    //}

    //public bool DeleteBook(int id)
    //{
    //    var book = _bookRepository.GetById(id);
    //    if (book != null)
    //    {
    //        _bookRepository.Delete(book);
    //        return true;
    //    }
    //    return false;
    //}