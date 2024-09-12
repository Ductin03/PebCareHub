using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;
using System.Threading.Tasks;

namespace PebCareHub.Services
{
    public interface IProductServices
    {
        Task<List<Product>> GetProductAsync();
        Task<bool> AddAsync(CreateProductRequestModel model);
        Task<bool> AddPetAsync(CreateProductRequestModel model);
        Task<bool> DeletePetAsync(Guid id);
        Task<bool> UpdatePetAsync(UpdateProduct_PetRequestModel model);
        Task<List<Pet>> GetPetAsync();
        
        
    }
}
