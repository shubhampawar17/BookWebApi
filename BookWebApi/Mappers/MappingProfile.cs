using AutoMapper;
using BookWebApi.DTOs;
using BookWebApi.Models;

namespace BookWebApi.Mappers
{
    public class MappingProfile : Profile
    {
        //mappings between object and DTO and vice versa
        public MappingProfile() 
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.TotalBooks, val => val.MapFrom(src => src.Books.Count));
            //CreateMap<AuthorDto, Author>();
            //convert authorDto to another using mappping

            CreateMap<AuthorDto , Author>();
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, val => val.MapFrom(src => src.Author.Name));

            CreateMap<BookDto, Book>();
            CreateMap<AuthorDetails, AuthorDetailsDto>()
                .ForMember(dest => dest.AuthorName, val => val.MapFrom(src => src.Author.Name));
            CreateMap<AuthorDetailsDto, AuthorDetails>();
        }
    }
}
