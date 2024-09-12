using PebCareHub.Models.ResponUserModel;

namespace PebCareHub.Services
{
    public interface ICategoryService
    {
        Task<bool> CreateProductCategory(CreateCategoryModel model);
        Task<bool> CreatePetCategoryAsync(CreateCategoryModel model);
    }
}
