using PebCareHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace PebCareHub.Repository
{
    public class CustormerRepository : ICustormerRepository
    {   
        private readonly PetHubDbContext _context;
        public CustormerRepository(PetHubDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(Custormer custormer)
        {
            _context.Custormers.Add(custormer);
            return Task.FromResult(true);
        }

        public Task<bool> Delete(Custormer custormer)
        {
            _context.Custormers.Remove(custormer);
            return Task.FromResult(true);
        }

        public async Task<List<Custormer>> GetAll()
        {
            return await _context.Custormers.ToListAsync();
        }

        public async Task<Custormer> GetById(Guid id)
        {
            return await _context.Custormers.FirstOrDefaultAsync(x => x.Id==id);    
        }

        public async Task<Custormer> GetByUserName(string username)
        {
            return await _context.Custormers.FirstOrDefaultAsync(x => x.UsersName == username);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> Update(Custormer custormer)
        {
            _context.Custormers.Update(custormer);
            return await Task.FromResult(true);
        }
    }

}
