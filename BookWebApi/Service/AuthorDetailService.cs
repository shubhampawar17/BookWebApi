using AutoMapper;
using BookWebApi.DTOs;
using BookWebApi.Exceptions;
using BookWebApi.Models;
using BookWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Service
{
    public class AuthorDetailsService : IAuthorDetailService
    {
        private readonly IRepository<AuthorDetails> _authorDetailsRepository;
        private readonly IMapper _mapper;

        public AuthorDetailsService(IRepository<AuthorDetails> authorDetailsRepository, IMapper mapper)
        {
            _authorDetailsRepository = authorDetailsRepository;
            _mapper = mapper;
        }
        ////2.Find AuthorDetail by AuthorId
        //public AuthorDetailsService GetAuthorDetailById(int authorId)
        //{
        //    return _authorDetailsRepository.AuthorDetails.FirstOrDefault(ad => ad.AuthorId == authorId);
        //}

        //public List<AuthorDetailsDto> GetAllAuthorDetails()
        //{
        //    var authorDetails = _authorDetailsRepository.GetAll().Include(a => a.Author).ToList();
        //    if (authorDetails == null)
        //        throw new AuthorDetailsNotFoundException($"Author Details not found");
        //    List<AuthorDetailsDto> authorDetailsDtos = _mapper.Map<List<AuthorDetailsDto>>(authorDetails);
        //    return authorDetailsDtos;
        //}

        public AuthorDetailsDto GetAuthorDetails(int id)
        {
            var authorDetail = _authorDetailsRepository.GetAll().Include(a => a.Author).FirstOrDefault(a => a.Id == id);
            if (authorDetail == null)
                throw new AuthorDetailsNotFoundException($"Author Details not found {id} with id {authorDetail.Id}");
            var authorDetailDto = _mapper.Map<AuthorDetailsDto>(authorDetail);
            return authorDetailDto;
        }
        public AuthorDetailsDto FindAuthorDetailsByAuthorId(int authorId)
        {
            var authorDetail = _authorDetailsRepository.GetAll().Include(a => a.Author).FirstOrDefault(b => b.Id == authorId);
            if (authorDetail == null)
                throw new AuthorDetailsNotFoundException($"Author Details Not Found {authorId}");
            var authorDetailsDto = _mapper.Map<AuthorDetailsDto>(authorDetail);
            return authorDetailsDto;
        }
        //public int AddAuthorDetails(AuthorDetailsDto authorDetailsDto)
        //{
        //    var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);
        //    _authorDetailsRepository.Add(authorDetails);
        //    return authorDetails.Id;
        //}

        //public AuthorDetailsDto UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto)
        //{
        //    var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);
        //    var existingAuthorDetails = _authorDetailsRepository.GetAll().Include(a => a.Author).AsNoTracking().FirstOrDefault(a => a.Id == authorDetails.Id);
        //    if (existingAuthorDetails != null)
        //    {
        //        _authorDetailsRepository.Update(authorDetails);
        //        return authorDetailsDto;
        //    }
        //    throw new AuthorDetailsNotFoundException($"Author Details not found {authorDetails.Id}");
        //}

        public bool DeleteAuthorDetails(int id)
        {
            var authorDetails = _authorDetailsRepository.GetById(id);
            if (authorDetails != null)
            {
                _authorDetailsRepository.Delete(authorDetails);
                return true;
            }
            throw new AuthorDetailsNotFoundException($"Author Details Not Found {id}");
        }

        List<AuthorDetailsDto> GetAuthorDetails()
        {
            var authorDetails = _authorDetailsRepository.GetAll().Include(a => a.Author).ToList();
            if (authorDetails == null)
                throw new AuthorDetailsNotFoundException($"Author Details not found");
            List<AuthorDetailsDto> authorDetailsDtos = _mapper.Map<List<AuthorDetailsDto>>(authorDetails);
            return authorDetailsDtos;
        }

        public int AddAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);
            _authorDetailsRepository.Add(authorDetails);
            return authorDetails.Id;
        }

        public List<AuthorDetailsDto> GetAllAuthorDetails()
        {
            var authorDetails = _authorDetailsRepository.GetAll().Include(a => a.Author).ToList();
            if (authorDetails == null)
                throw new AuthorDetailsNotFoundException($"Author Details not found");
            List<AuthorDetailsDto> authorDetailsDtos = _mapper.Map<List<AuthorDetailsDto>>(authorDetails);
            return authorDetailsDtos;
        }

        public AuthorDetailsDto UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);
            var existingAuthorDetails = _authorDetailsRepository.GetAll().Include(a => a.Author).AsNoTracking().FirstOrDefault(a => a.Id == authorDetails.Id);
            if (existingAuthorDetails != null)
            {
                _authorDetailsRepository.Update(authorDetails);
                return authorDetailsDto;
            }
            throw new AuthorDetailsNotFoundException($"Author Details not found {authorDetails.Id}");
        }

        //public AuthorDetailsDto UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto)
        //{
        //    var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);
        //    var existingAuthorDetails = _authorDetailsRepository.GetAll().Include(a => a.Author).AsNoTracking().FirstOrDefault(a => a.Id == authorDetails.Id);
        //    if (existingAuthorDetails != null)
        //    {
        //        _authorDetailsRepository.Update(authorDetails);
        //        return authorDetailsDto;
        //    }
        //    throw new AuthorDetailsNotFoundException($"Author Details not found {authorDetails.Id}");
        //}


    }
    //public class AuthorDetailsService : IAuthorDetailService
    //{
    //    private readonly IRepository<AuthorDetails> _authorDetailsRepository;
    //    private readonly IMapper _mapper;

    //    public AuthorDetailsService(IRepository<AuthorDetails> authorDetailsRepository , IMapper mapper)
    //    {
    //        _authorDetailsRepository = authorDetailsRepository;
    //        _mapper = mapper;
    //    }

    //    public List<AuthorDetails> GetAllAuthorDetails()
    //    {
    //        return _authorDetailsRepository.GetAll();
    //    }

    //    public AuthorDetails GetAuthorDetails(int id)
    //    {
    //        return _authorDetailsRepository.Get(id);
    //    }

    //    public int AddAuthorDetails(AuthorDetailsDto authorDetailsDto )
    //    {
    //        var author = _mapper.Map<AuthorDetails>( authorDetailsDto );
    //        _authorDetailsRepository.Add( author );
    //        return author.Id;
    //    }

    //    public bool UpdateAuthorDetails(AuthorDetails authorDetails)
    //    {
    //        var existingDetails = _authorDetailsRepository.Get(authorDetails.Id);
    //        if (existingDetails != null)
    //        {
    //            _authorDetailsRepository.Update(authorDetails);
    //            return true;
    //        }
    //        return false;
    //    }

    //    public bool DeleteAuthorDetails(int id)
    //    {
    //        var authorDetails = _authorDetailsRepository.Get(id);
    //        if (authorDetails != null)
    //        {
    //            _authorDetailsRepository.Delete(authorDetails);
    //            return true;
    //        }
    //        return false;
    //    }
    //}
}
