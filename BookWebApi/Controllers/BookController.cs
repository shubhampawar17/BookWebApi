using BookWebApi.DTOs;
using BookWebApi.Models;
using BookWebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        //[HttpGet("author/{Name}")]
        //public IActionResult GetAuthorByName(string name)
        //{
        //    var author = _bookService.GetAuthorByName(name);
        //    return author != null ? Ok(author) : BadRequest();
        //}
        //[HttpGet("authordetail/{authorId}")]
        //public IActionResult GetAuthorDetailById(int authorId)
        //{
        //    var authorDetail = _bookService.GEtAuthorDetailById(authorId);
        //    return authorDetail != null ? Ok(authorDetail) : BadRequest();
        //}
        [HttpGet("Author/{authorId}")]
        public IActionResult FindBooksByAuthorId(int authorId)
        {
            var bookDtos = _bookService.FindBookByAuthorId(authorId);
            return Ok(bookDtos);
        }
        [HttpGet("Book/{bookId}")]
        public IActionResult FindAuthorByBookId(int bookId)
        {
            var authorDto = _bookService.FindAuthorByBookId(bookId);
            return Ok(authorDto);
        }
        // Get all books
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookDtos = _bookService.GetAllBooks();
            return Ok(bookDtos);
        }

        // Get book by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound("Book not found.");
            return Ok(book);
        }

        // Add new book
        [HttpPost]
        public IActionResult Add(BookDto bookDto)
        {
            var newId = _bookService.AddBook(bookDto);
            return Ok($"Book added {newId}");
        }

        // Update existing book
        [HttpPut]
        public IActionResult Update(BookDto updatedBookDto)
        {
            var bookDtos = _bookService.UpdateBook(updatedBookDto);
            return Ok(bookDtos); 
        }

        // Delete a book by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return Ok($"Book Deleted {id}");
        }
    }
}