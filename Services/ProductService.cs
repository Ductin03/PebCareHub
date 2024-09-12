using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;
using PebCareHub.UniOfWork;
using System.Drawing;

namespace PebCareHub.Services
{
    public class ProductService : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(CreateProductRequestModel model)
        {
            var product = new Product();
            product.Id = new Guid();
            product.ProductName = model.ProductName;
            product.CategoryId = model.CategoryId;
            product.Description = model.ProductDescription;
            product.ImageUrl = model.ImageUrl;
            product.StockQuantity = model.StockQuanlity;
            product.Price = model.Price;
            product.SellerId = model.SellerId;
            product.CreatedBy = model.CreateBy;
            await _unitOfWork.ProductRepository.CreateProduct(product);
            return await _unitOfWork.SaveChangesAsync();
            

        }

        public async Task<bool> AddPetAsync(CreateProductRequestModel model)
        {
            var pet=new Pet();
            pet.Id = new Guid();
            pet.PetName = model.ProductName;
            pet.CategoryId = model.CategoryId;
            pet.Description = model.ProductDescription;
            pet.ImageUrl = model.ImageUrl;
            pet.StockQuantity = model.StockQuanlity;
            pet.Price = model.Price;
            pet.SellerId = model.SellerId;
            pet.CreatedBy = model.CreateBy;
            await _unitOfWork.ProductRepository.CreatePet(pet);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeletePetAsync(Guid id)
        {
            var IdExist= await _unitOfWork.ProductRepository.GetById(id);
            if (IdExist==null)
            {
                throw new Exception("Không tìm thấy id");
            }

            await _unitOfWork.ProductRepository.DeletePet(IdExist);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Pet>> GetPetAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllPet();
        }

        public async Task<List<Product>> GetProductAsync()
        {
            return await _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<bool> UpdatePetAsync(UpdateProduct_PetRequestModel model)
        {
            var pet = await _unitOfWork.ProductRepository.GetById(model.ProductId);
            if (pet == null)
            {
                throw new Exception("Không tìm thấy id");
            }
            pet.Id = model.ProductId;
            pet.PetName = model.ProductName;
            pet.Description = model.ProductDescription;
            pet.ImageUrl = model.ImageUrl;
            pet.StockQuantity = model.StockQuanlity;
            pet.Price = model.Price;
            await _unitOfWork.ProductRepository.UpdatePet(pet);
            return await _unitOfWork.SaveChangesAsync();
            
        }
    }
}