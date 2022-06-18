using Project.BLL.DTO.Requests;
using Project.BLL.DTO.Responses;

namespace Project.BLL.Interfaces.Services
{

    public interface IGenreService
    {
        Task<IEnumerable<GenreResponse>> GetAsync();
        Task<GenreResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(GenreRequest request);
        Task UpdateAsync(GenreRequest request);
        Task DeleteAsync(int id);
    }

}