using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;
using PebCareHub.UniOfWork;

namespace PebCareHub.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public CategoryService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreatePetCategoryAsync(CreateCategoryModel model)
        {
            var petcategory = new PetCategory();
            petcategory.Id = Guid.NewGuid();
            petcategory.CategoryName = model.CategoryName;
            petcategory.Description = model.Description;
            petcategory.CreatedBy = model.CreateBy;
            await _unitOfWork.CategoryRepository.CreatePetCateGory(petcategory);
            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> CreateProductCategory(CreateCategoryModel model)
        {
            var product = new ProductCategory();
            product.Id = Guid.NewGuid();
            product.CategoryName = model.CategoryName;
            product.Description = model.Description;
            product.CreatedBy = model.CreateBy;
            await _unitOfWork.CategoryRepository.CreateCategory(product);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
