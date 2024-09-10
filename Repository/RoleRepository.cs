using Microsoft.EntityFrameworkCore;
using PebCareHub.Entities;

namespace PebCareHub.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly PetHubDbContext _context;
        public RoleRepository(PetHubDbContext context)
        {
            _context = context;
        }
        public async Task<Role> GetRoleById(Guid userId)
        {
            return (await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == userId))?.Role;
        }
    }
}
