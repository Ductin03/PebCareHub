using PebCareHub.Entities;

namespace PebCareHub.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PetHubDbContext _context;
        public CategoryRepository(PetHubDbContext context)
        {
            _context = context;
        }
        public Task<bool> CreateCategory(ProductCategory productCategory)
        {
            _context.ProductsCategory.AddAsync(productCategory);
            return Task.FromResult(true);
        }
        public Task<bool> CreatePetCateGory(PetCategory petCategory)
        {
            _context.Petcategory.AddAsync(petCategory);
            return Task.FromResult(true);
        }
    }
}
