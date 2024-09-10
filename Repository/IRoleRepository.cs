using PebCareHub.Entities;
namespace PebCareHub.Repository
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(Guid userId);
        
    }
}
