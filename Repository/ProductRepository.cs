using PebCareHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace PebCareHub.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PetHubDbContext _context;
        public ProductRepository(PetHubDbContext context)
        {
            _context = context;
        }

        public Task<bool> CreatePet(Pet pet)
        {
            _context.Pets.Add(pet);
            return Task.FromResult(true);
        }

        public Task<bool> CreateProduct(Product product)
        {
            _context.Products.AddAsync(product);
            return Task.FromResult(true);
            
        }

        public Task<bool> DeletePet(Pet pet)
        {
            _context.Pets.Remove(pet);
            return Task.FromResult(true);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Pet>> GetAllPet()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetById(Guid id)
        {
            return await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> UpdatePet(Pet pet)
        {
           _context.Pets.Update(pet);
            return await Task.FromResult(true);
        }
    }
}
