using PebCareHub.Entities;
using Microsoft.EntityFrameworkCore;
using PebCareHub.Models.ResponUserModel;

namespace PebCareHub.Repository
{
    public class CustormerRepository : ICustormerRepository
    {   
        private readonly PetHubDbContext _context;
        public CustormerRepository(PetHubDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(User custormer)
        {
            _context.Users.AddAsync(custormer);
            return Task.FromResult(true);
        }

        public Task<bool> CreateRole(Role role)
        {
            _context.Roles.AddAsync(role);
            return Task.FromResult(true);
        }

        public Task<bool> Delete(User custormer)
        {
            _context.Users.Remove(custormer);
            return Task.FromResult(true);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id==id);    
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> Update(User user)
        {
            _context.Users.Update(user);
            return await Task.FromResult(true);
        }
    }

}
