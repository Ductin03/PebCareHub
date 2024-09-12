using PebCareHub.Entities;

namespace PebCareHub.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<bool> CreateProduct(Product product);
        Task<List<Pet>> GetAllPet();
        Task<bool> CreatePet(Pet pet);
        Task<bool> DeletePet(Pet pet);
        Task<bool> UpdatePet(Pet pet);
        Task<Pet> GetById(Guid id);


    }

}
