using AutoMapper;
using Project.BLL.DTO.Requests;
using Project.BLL.DTO.Responses;
using Project.DAL.Entities;


namespace Project.BLL.Configuration.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        private void CreateSeanceMaps()
        {
            CreateMap<Seance, SeanceResponse>();
            CreateMap<SeanceRequest, Seance>();
        }
        private void CreateGenreMaps()
        {
            CreateMap<Genre, GenreResponse>();
            CreateMap<GenreRequest, Genre>();
        }
        private void CreateMovieMaps()
        {
            CreateMap<Movie, MovieResponse>();
            CreateMap<MovieRequest, Movie>();
        }
        private void CreateMovieGenreMaps()
        {
            CreateMap<MovieGenre, MovieGenreResponse>();
            CreateMap<MovieGenreRequest, MovieGenre>();
        }

        public AutoMapperProfile()
        {
            CreateSeanceMaps();
            CreateGenreMaps();
            CreateMovieMaps();
            CreateMovieGenreMaps();
        }

    }
}
