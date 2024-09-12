using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PebCareHub.Attributes;
using PebCareHub.Models.ResponUserModel;
using PebCareHub.Services;

namespace PebCareHub.Controllers
{
    [AuthorizeRoles(RoleModel.Administrator,RoleModel.Employee)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IConfiguration _configuration;
        public ProductController(IProductServices productServices, IConfiguration configuration)
        {
            _productServices = productServices;
            _configuration = configuration;
        }
        [HttpGet("Product")]
        public async Task<IActionResult> GetCustomer()
        {
            return Ok(await _productServices.GetProductAsync());
        }
        [HttpGet("Pet")]
        public async Task<IActionResult> GetAllPet()
        {
            return Ok( await _productServices.GetPetAsync());
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestModel request)
        {
            return Ok(await _productServices.AddAsync(request));
        }
        [HttpPost("createPet")]
        public async Task<IActionResult> AddPet([FromBody] CreateProductRequestModel request)
        {
            return Ok( await _productServices.AddPetAsync(request));
        }
        [HttpDelete("delete/{petid}")]
        public async Task<IActionResult> DeletePet([FromRoute] Guid petid)
        {
            return Ok(await _productServices.DeletePetAsync(petid));

        }
        [HttpPost("UpdatePet")]
        public async Task<IActionResult> UpdatePet([FromBody] UpdateProduct_PetRequestModel request)
        {
            return Ok(await _productServices.UpdatePetAsync(request));
        }
    }

}
