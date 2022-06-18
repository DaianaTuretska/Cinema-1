using AutoMapper;
using Project.BLL.Interfaces.Services;
using Project.DAL.Interfaces.Repositories;
using Project.DAL.Entities;
using Project.DAL.Interfaces.Repositories.Base;
using Project.BLL.DTO.Responses;
using Project.BLL.DTO.Requests;

namespace Project.BLL.Services
{
    public class MovieGenreService : IMovieGenreService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IMovieGenreRepository movieGenreRepository;


        public async Task<IEnumerable<MovieGenreResponse>?> GetAsync()
        {
            var movieGenre = await movieGenreRepository.GetAllAsync();
            return movieGenre?.Select(mapper.Map<MovieGenre, MovieGenreResponse>);
        }

        public async Task<MovieGenreResponse> GetByIdAsync(int id)
        {
            var movieGenre = await movieGenreRepository.GetAsync(id);
            return mapper.Map<MovieGenre, MovieGenreResponse>(movieGenre);
        }

        public async Task<int> InsertAsync(MovieGenreRequest request)
        {
            var movieGenre = mapper.Map<MovieGenreRequest, MovieGenre>(request);
            var movieGenre_id = await movieGenreRepository.AddAsync(movieGenre);
            return movieGenre_id;
        }

        public async Task UpdateAsync(MovieGenreRequest request)
        {
            var movieGenre = mapper.Map<MovieGenreRequest, MovieGenre>(request);
            await movieGenreRepository.ReplaceAsync(movieGenre);
        }

        public async Task DeleteAsync(int id)
        {
            await movieGenreRepository.DeleteAsync(id);
        }

        public MovieGenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            movieGenreRepository = this.unitOfWork._movieGenreRepository;
        }
    }
}
