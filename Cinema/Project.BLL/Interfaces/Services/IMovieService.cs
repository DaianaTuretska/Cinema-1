using Project.BLL.DTO.Requests;
using Project.BLL.DTO.Responses;

namespace Project.BLL.Interfaces.Services
{

    public interface IMovieService
    {
        Task<IEnumerable<MovieResponse>> GetAsync();
        Task<MovieResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(MovieRequest request);
        Task UpdateAsync(MovieRequest request);
        Task DeleteAsync(int id);
    }

}