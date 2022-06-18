using Project.BLL.DTO.Requests;
using Project.BLL.DTO.Responses;

namespace Project.BLL.Interfaces.Services
{

    public interface IMovieGenreService
    {
        Task<IEnumerable<MovieGenreResponse>> GetAsync();
        Task<MovieGenreResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(MovieGenreRequest request);
        Task UpdateAsync(MovieGenreRequest request);
        Task DeleteAsync(int id);
    }

}