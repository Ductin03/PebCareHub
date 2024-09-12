using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PebCareHub.Models.ResponUserModel;
using PebCareHub.Repository;
using PebCareHub.Services;

namespace PebCareHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICategoryService _categoryService;
        public CategoryController( IConfiguration configuration, ICategoryService categoryService)
        {
            _configuration = configuration;
            _categoryService = categoryService;
        }


        [HttpPost("PetCategory")]
        public async Task<IActionResult> PetCategory([FromBody] CreateCategoryModel request)
        {
            return Ok(await _categoryService.CreatePetCategoryAsync(request));
        }


        [HttpPost("ProductCategory")]
        public async Task<IActionResult> ProductCategory([FromBody] CreateCategoryModel request)
        {
            return Ok(await _categoryService.CreateProductCategory(request));
        }


    }
}
