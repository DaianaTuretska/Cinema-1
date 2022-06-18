﻿using Project.BLL.DTO.Requests;
using Project.BLL.DTO.Responses;

namespace Project.BLL.Interfaces.Services
{

    public interface ISeanceService
    {
        Task<IEnumerable<SeanceResponse>> GetAsync();
        Task<SeanceResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(SeanceRequest request);
        Task UpdateAsync(SeanceRequest request);
        Task DeleteAsync(int id);
    }

}