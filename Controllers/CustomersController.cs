using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PebCareHub.Models.ResponUserModel;
using PebCareHub.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PebCareHub.Controllers
{
    [Authorize]
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
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            return Ok(await _customerService.GetCustormersAsync());
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestModel request)
        {
            var isAuthen = await _customerService.Authenzication(request.UserName, request.Password);
            if (!isAuthen)
            {
                return Unauthorized("Not Login");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, request.UserName)
            }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            //Response.Headers.Add("Authorization", $"Bearer {tokenString}");

            return Ok(new { Token = tokenString });
        }
        

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestModel request)
        {
            return Ok(await _customerService.CreateUsersAsync(request));
        }
        [HttpPost("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            return Ok(await _customerService.DeleteUserAsync(userId));

        }
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestModel request)
        {
            return Ok(await _customerService.UpdateAsync(request));
        }


    }


        

        


        

    }

