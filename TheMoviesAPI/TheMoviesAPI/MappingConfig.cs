using AutoMapper;
using TheMoviesAPI.Models;
using TheMoviesAPI.Models.Dto;

namespace TheMoviesAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
        
            CreateMap<Movie,MovieDTO>().ReverseMap();
            CreateMap<Movie,CreateMovieDTO>().ReverseMap();
            CreateMap<Movie,UpdateMovieDTO>().ReverseMap();
        }
    }
}
