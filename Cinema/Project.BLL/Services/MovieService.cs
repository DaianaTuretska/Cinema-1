using AutoMapper;
using Project.BLL.Interfaces.Services;
using Project.DAL.Interfaces.Repositories;
using Project.DAL.Entities;
using Project.DAL.Interfaces.Repositories.Base;
using Project.BLL.DTO.Responses;
using Project.BLL.DTO.Requests;

namespace Project.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IMovieRepository movieRepository;


        public async Task<IEnumerable<MovieResponse>?> GetAsync()
        {
            var movie = await movieRepository.GetAllAsync();
            return movie?.Select(mapper.Map<Movie, MovieResponse>);
        }

        public async Task<MovieResponse> GetByIdAsync(int id)
        {
            var movie = await movieRepository.GetAsync(id);
            return mapper.Map<Movie, MovieResponse>(movie);
        }

        public async Task<int> InsertAsync(MovieRequest request)
        {
            var movie = mapper.Map<MovieRequest, Movie>(request);
            var movie_id = await movieRepository.AddAsync(movie);
            return movie_id;
        }

        public async Task UpdateAsync(MovieRequest request)
        {
            var movie = mapper.Map<MovieRequest, Movie>(request);
            await movieRepository.ReplaceAsync(movie);
        }

        public async Task DeleteAsync(int id)
        {
            await movieRepository.DeleteAsync(id);
        }

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            movieRepository = this.unitOfWork._movieRepository;
        }
    }
}
