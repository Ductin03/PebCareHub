using PebCareHub.Entities;
using PebCareHub.Repository;
using System.Data.Entity;

namespace PebCareHub.UniOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetHubDbContext _context;
        private readonly ICustormerRepository _custormerRepository;
        private readonly IRoleRepository _roleRepository;

        public CustormerRepository Custormer { get; }

        public UnitOfWork(PetHubDbContext context,ICustormerRepository custormerRepository,IRoleRepository roleRepository)
        {
            _context = context;
            _custormerRepository = custormerRepository;
            _roleRepository = roleRepository;
        }


        public ICustormerRepository Customer => _custormerRepository;
        public IRoleRepository Roles => _roleRepository;

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync()>0;

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
