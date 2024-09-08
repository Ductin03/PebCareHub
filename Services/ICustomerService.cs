using PebCareHub.Entities;
using PebCareHub.Models.ResponUserModel;

namespace PebCareHub.Services
{
    public interface ICustomerService
    {
        Task<List<Custormer>> GetCustormersAsync();
        Task<bool> Authenzication(string username,string password);

        Task<bool> CreateUsersAsync(CreateUserRequestModel request);
        Task<bool> DeleteUserAsync(Guid Id);
        Task<bool> UpdateAsync(UpdateUserRequestModel request);
    }
}
