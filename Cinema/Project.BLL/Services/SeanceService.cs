using AutoMapper;
using Project.BLL.Interfaces.Services;
using Project.DAL.Interfaces.Repositories;
using Project.DAL.Entities;
using Project.DAL.Interfaces.Repositories.Base;
using Project.BLL.DTO.Responses;
using Project.BLL.DTO.Requests;

namespace Project.BLL.Services
{
    public class SeanceService : ISeanceService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly ISeanceRepository seanceRepository;


        public async Task<IEnumerable<SeanceResponse>> GetAsync()
        {
            var seance = await seanceRepository.GetAllAsync();
            return seance?.Select(mapper.Map<Seance, SeanceResponse>);
        }

        public async Task<SeanceResponse> GetByIdAsync(int id)
        {
            var seance = await seanceRepository.GetAsync(id);
            return mapper.Map<Seance, SeanceResponse>(seance);
        }

        public async Task<int> InsertAsync(SeanceRequest request)
        {
            var seance = mapper.Map<SeanceRequest, Seance>(request);
            var seance_id = await seanceRepository.AddAsync(seance);
            return seance_id;
        }

        public async Task UpdateAsync(SeanceRequest request)
        {
            var seance = mapper.Map<SeanceRequest, Seance>(request);
            await seanceRepository.ReplaceAsync(seance);
        }

        public async Task DeleteAsync(int id)
        {
            await seanceRepository.DeleteAsync(id);
        }

        public SeanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            seanceRepository = this.unitOfWork._seanceRepository;
        }

    }
}
