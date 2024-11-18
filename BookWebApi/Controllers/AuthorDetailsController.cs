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
    public class AuthorDetailsController : ControllerBase
    {
        private readonly IAuthorDetailService _authorDetailsService;
        //private readonly IMapper _mapper;
        public AuthorDetailsController(IAuthorDetailService authorDetailsService)
        {
            _authorDetailsService = authorDetailsService;
            //_mapper = mapper;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDetails = _authorDetailsService.GetAllAuthorDetails();
            //List<AuthorDetailsDto> authorDetailsDtos = _mapper.Map<List<AuthorDetailsDto>>(authorDetails);  
            return Ok(authorDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var authorDetail = _authorDetailsService.GetAuthorDetails(id);
            //if (authorDetail == null) return NotFound("Author details not found.");
            return Ok(authorDetail);
        }

        [HttpPost]
        public IActionResult Add(AuthorDetailsDto authorDetailDto)
        {
            _authorDetailsService.AddAuthorDetails(authorDetailDto);
            return Ok("Author Added");
        }

        [HttpPut]
        public IActionResult Update(AuthorDetailsDto updatedAuthorDetailDto)
        {
            var authorDetails = _authorDetailsService.UpdateAuthorDetails(updatedAuthorDetailDto);
            return Ok(authorDetails);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_authorDetailsService.DeleteAuthorDetails(id))
            {
                return Ok("Author Details Deleted Succcessfully");
            }
            return NotFound("Author details not found.");
        }
        //[HttpGet("Author/{authorId}")]
        //public IActionResult GetAuthorDetailsByAuthorId(int authorId)
        //{
        //    var authorDetail = _authorDetailsService.FindAuthorDetailsByAuthorId(authorId);
        //    return Ok(authorDetail);
        //}
    }
}