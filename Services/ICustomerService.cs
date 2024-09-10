using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;

namespace PebCareHub.Services
{
    public interface ICustomerService
    {
        Task<List<User>> GetCustormersAsync();
        Task<string> Authenzication(string username,string password);

        Task<bool> CreateUsersAsync(CreateUserRequestModel request);
        Task<bool> DeleteUserAsync(Guid Id);
        Task<bool> UpdateAsync(UpdateUserRequestModel request);
        Task<bool> CreateRole(CreateRoleRequestModel request);
    }
}
