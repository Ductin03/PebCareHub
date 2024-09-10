using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PebCareHub.Attributes;
using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;
using PebCareHub.Repository;
using PebCareHub.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PebCareHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _configuration;
        public CustomersController(ICustomerService customerService,IConfiguration configuration)
        {
            _customerService = customerService;
            _configuration = configuration;

        }
        [AuthorizeRoles("Administrator")]
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            return Ok(await _customerService.GetCustormersAsync());
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestModel request)
        {
            string token = await _customerService.Authenzication(request.UserName, request.Password);
            return Ok(new { Token = token });
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestModel request)
        {
            return Ok(await _customerService.CreateUsersAsync(request));
        }
        [HttpPost("{userId}")] // HTTP DELETE
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            return Ok(await _customerService.DeleteUserAsync(userId));

        }
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestModel request)
        {
            return Ok(await _customerService.UpdateAsync(request));
        }
        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequestModel request)
        {
            return Ok(await _customerService.CreateRole(request));
        }
     

    }


        

        


        

    }

