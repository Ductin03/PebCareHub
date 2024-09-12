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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UsersController(IUserService userService,IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;

        }
        [AuthorizeRoles(RoleModel.Administrator,RoleModel.User)]
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            return Ok(await _userService.GetCustormersAsync());
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestModel request)
        {
            string token = await _userService.Authenzication(request.UserName, request.Password);
            return Ok(new { Token = token });
        }


        //[AuthorizeRoles(RoleModel.Administrator)]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestModel request)
        {
            return Ok(await _userService.CreateUsersAsync(request));
        }


        [AuthorizeRoles(RoleModel.Administrator)]
        [HttpDelete("delete/{userId}")] // HTTP DELETE
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            return Ok(await _userService.DeleteUserAsync(userId));

        }


        [AuthorizeRoles(RoleModel.Administrator)]
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestModel request)
        {
            return Ok(await _userService.UpdateAsync(request));
        }


        //[AuthorizeRoles(RoleModel.Administrator)]
        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequestModel request)
        {
            return Ok(await _userService.CreateRole(request));
        }
     

    }


        

        


        

    }

