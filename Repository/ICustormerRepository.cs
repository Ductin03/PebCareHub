using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;

namespace PebCareHub.Repository
{
    public interface ICustormerRepository
    {

        Task<List<User>> GetAll();
        Task<User> GetByUserName(String username);
        Task<User> GetById(Guid Id);
        Task<bool> Create(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(User user);
        Task<bool> CreateRole(Role role);
        Task<bool> SaveChangeAsync();
    }
}
