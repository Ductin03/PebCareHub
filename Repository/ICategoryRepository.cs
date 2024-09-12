using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;

namespace PebCareHub.Repository
{
    public interface ICategoryRepository
    {
        public Task<bool> CreateCategory(ProductCategory productCategory);
        public Task<bool> CreatePetCateGory(PetCategory petCategory);
    }
}
