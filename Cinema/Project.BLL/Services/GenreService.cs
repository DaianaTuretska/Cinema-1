using AutoMapper;
using Project.BLL.Interfaces.Services;
using Project.DAL.Interfaces.Repositories;
using Project.DAL.Entities;
using Project.DAL.Interfaces.Repositories.Base;
using Project.BLL.DTO.Responses;
using Project.BLL.DTO.Requests;

namespace Project.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IGenreRepository genreRepository;


        public async Task<IEnumerable<GenreResponse>?> GetAsync()
        {
            var genre = await genreRepository.GetAllAsync();
            return genre?.Select(mapper.Map<Genre, GenreResponse>);
        }

        public async Task<GenreResponse> GetByIdAsync(int id)
        {
            var genre = await genreRepository.GetAsync(id);
            return mapper.Map<Genre, GenreResponse>(genre);
        }

        public async Task<int> InsertAsync(GenreRequest request)
        {
            var genre = mapper.Map<GenreRequest, Genre>(request);
            var genre_id = await genreRepository.AddAsync(genre);
            return genre_id;
        }

        public async Task UpdateAsync(GenreRequest request)
        {
            var genre = mapper.Map<GenreRequest, Genre>(request);
            await genreRepository.ReplaceAsync(genre);
        }

        public async Task DeleteAsync(int id)
        {
            await genreRepository.DeleteAsync(id);
        }

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            genreRepository = this.unitOfWork._genreRepository;
        }
    }
}
