using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;
using PebCareHub.Repository;
using System.Configuration;

namespace PebCareHub.Services
{
    public class CustormerService : ICustomerService
    {
        private readonly ICustormerRepository _custormerRepository;

        public CustormerService(ICustormerRepository custormerRepository)
        {
            _custormerRepository = custormerRepository;
        }

        public async Task<bool> Authenzication(string username, string password)
        {
            var user = await _custormerRepository.GetByUserName(username);
            if (user == null||user.PassWord!=password) {
                return false;
            }
            return true;
        }

        public async Task<bool> CreateUsersAsync(CreateUserRequestModel request)

        {
            var user = new Custormer();
            user.Id = Guid.NewGuid();
            user.Name = request.Name;
            user.UsersName = request.UserName;
            user.PassWord = request.Password;
            user.Email = request.Email;
            var check= await _custormerRepository.GetByUserName(request.UserName);
            if (check==null) { 
                await _custormerRepository.Create(user);
                return await _custormerRepository.SaveChangeAsync();
            }
            return false;
          
        }

        public async Task<bool> DeleteUserAsync(Guid Id)
        {
            var checkId = await _custormerRepository.GetById(Id);
            await _custormerRepository.Delete(checkId);
            return await _custormerRepository.SaveChangeAsync();
        } 

        public async Task<List<Custormer>> GetCustormersAsync()
        {
            return await _custormerRepository.GetAll();
        }

        public async Task<bool> UpdateAsync(UpdateUserRequestModel request)
        {
            var UserExist = await _custormerRepository.GetById(request.Id);
            if (UserExist == null)
            {
                throw new Exception("Khoong cos Id");
            }
            UserExist.Id = request.Id;
            UserExist.Name = request.Name;
            UserExist.UsersName= request.UserName;
            UserExist.PassWord= request.Password;
            UserExist.Email = request.Email;
            await _custormerRepository.Update(UserExist);
            return await _custormerRepository.SaveChangeAsync();
        }
    }
}
