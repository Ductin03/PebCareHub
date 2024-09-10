using PebCareHub.Entities;
using PebCareHub.Repository;
using PebCareHub.UniOfWork;
using System.Data.Entity;

namespace PebCareHub.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Role> GetRoleByUserIdAsync(Guid userId)
        {
            return  _unitOfWork.Roles.GetRoleById(userId);
        }
    }

}
