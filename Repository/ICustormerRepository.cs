using PebCareHub.Entities;

namespace PebCareHub.Repository
{
    public interface ICustormerRepository
    {

        Task<List<Custormer>> GetAll();
        Task<Custormer> GetByUserName(String username);
        Task<Custormer> GetById(Guid Id);
        Task<bool> Create(Custormer custormer);
        Task<bool> Update(Custormer custormer);
        Task<bool> Delete(Custormer custormer);
        Task<bool> SaveChangeAsync();
    }
}
