using AutoMapper;
using BookWebApi.DTOs;
using BookWebApi.Models;
using BookWebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        //private readonly IBookService _bookService; 
        public AuthorController(IAuthorService authorservice )
        {
            _authorService = authorservice;
            //_bookService = bookService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDtos = _authorService.GetAuthors();
            //List<AuthorDto>authorDtos = _mapper.Map<List<AuthorDto>>(authors);  
            return Ok(authorDtos);
            //=======================================
            //List<AuthorDto> result = new List<AuthorDto>();
            //var authors = _authorService.GetAuthors();
            //foreach (var author in authors)
            //{
            //    result.Add(new AuthorDto()
            //    {
            //        Id = author.Id,
            //        Name = author.Name,
            //        Email = author.Email,
            //        TotalBooks = author.Books.Count()
            //    });
            //}
            //return Ok(result);
            //===============================================
            //var authors = _authorService.GetAuthors();
            //return Ok(authors);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorService.GetAuthor(id);
            if (author == null)
                return NotFound("Author not found");
            return Ok(author);
        }
        [HttpPost]
        public IActionResult Add(AuthorDto authorDto)
        {
            int id = _authorService.AddAuthor(authorDto);
            ////return CreatedAtAction(nameof(Get), new { id = newId }, author);
            return Ok($"Added Successfully{id}");
            //var author = new Author()
            //{
            //    Name = authorDto.Name,
            //    Email = authorDto.Email,
            //};
            //var newAuthorId = _authorService.AddAuthor(authorDto);
            //return Ok(newAuthorId);

        }
        [HttpPut]
        public IActionResult Update(AuthorDto updatedAuthorDto)
        {
            var modifiedAuthor = _authorService.UpdateAuthor(updatedAuthorDto);   
            if(modifiedAuthor != null)
            {
                return Ok(modifiedAuthor);
            }
            return NotFound("no such author found");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleteStatus = _authorService.DeleteAuthor(id);
            if (deleteStatus)
                return Ok("Author deleted successfully");
            return NotFound("Author not found");
        }
        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var authorDto = _authorService.FindAuthorByName(name);
            return Ok(authorDto);
        }
        //[HttpGet("book/{bookId}")]
        //public IActionResult GetAuthorByBookId(int id)
        //{
        //    var authorDto = _bookService.GetAuthorByBookId(id);
        //    return Ok(authorDto);
        //}
    }

}
