using PebCareHub.Entities;
using PebCareHub.Repository;
using System.Data.Entity;

namespace PebCareHub.UniOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetHubDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public UserRepository Custormer { get; }

        public UnitOfWork(PetHubDbContext context, IUserRepository userRepository,IRoleRepository roleRepository, ICategoryRepository categoryRepository,IProductRepository productRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }


        public IUserRepository UserRepository => _userRepository;
        public IRoleRepository RoleRepository => _roleRepository;


        public ICategoryRepository CategoryRepository => _categoryRepository;

        public IProductRepository ProductRepository => _productRepository;

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
