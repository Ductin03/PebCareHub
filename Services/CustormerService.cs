using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;
using PebCareHub.Repository;
using PebCareHub.UniOfWork;
using System.Configuration;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PebCareHub.Services
{
    public class CustormerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public CustormerService(
            IUnitOfWork unitOfWork,
            IConfiguration configuration
            )
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<string> Authenzication(string username, string password)
        {
            var user = await _unitOfWork.Customer.GetByUserName(username);
            var isAuthen = user.Password == password; // Nhớ Hash;
            if (!isAuthen)
            {
                throw new UnauthorizedAccessException("UnAuthorized");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email.ToString()),                       // Email claim
                        new Claim("RoleName", user.Role.RoleName.ToString()),                    // Custom Role ID claim
                    }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> CreateRole(CreateRoleRequestModel request)
        {
            var role = new Role();
            role.RoleName = request.RoleName;
            role.Description = request.Description;
            role.CreateDate = DateTime.Now;
            role.UpdateDate = DateTime.Now;
            await _unitOfWork.Customer.CreateRole(role);
            return await _unitOfWork.Customer.SaveChangeAsync();
        }

        public async Task<bool> CreateUsersAsync(CreateUserRequestModel request)

        {
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Name = request.Name;
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Email = request.Email;
            user.RoleId = request.RoleId;
            user.CreateDate = DateTime.Now;
            user.CreatedBy = request.CreatedBy;
            var check = await _unitOfWork.Customer.GetByUserName(request.UserName);
            if (check == null)
            {
                await _unitOfWork.Customer.Create(user);
                return await _unitOfWork.Customer.SaveChangeAsync();
            }
            return false;

        }

        public async Task<bool> DeleteUserAsync(Guid Id)
        {
            var checkId = await _unitOfWork.Customer.GetById(Id);
            await _unitOfWork.Customer.Delete(checkId);
            return await _unitOfWork.Customer.SaveChangeAsync();
        }

        public async Task<List<User>> GetCustormersAsync()
        {
            return await _unitOfWork.Customer.GetAll();
        }

        public async Task<bool> UpdateAsync(UpdateUserRequestModel request)
        {
            var UserExist = await _unitOfWork.Customer.GetById(request.Id);
            if (UserExist == null)
            {
                throw new Exception("Khoong cos Id");
            }
            UserExist.Id = request.Id;
            UserExist.Name = request.Name;
            UserExist.UserName = request.UserName;
            UserExist.Password = request.Password;
            UserExist.Email = request.Email;
            await _unitOfWork.Customer.Update(UserExist);
            return await _unitOfWork.Customer.SaveChangeAsync();
        }
    }
}
