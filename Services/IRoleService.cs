using PebCareHub.Entities;

namespace PebCareHub.Services
{
    public interface IRoleService
    {
        Task<Role> GetRoleByUserIdAsync(Guid userId);
    }
}
