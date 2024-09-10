
using PebCareHub.Repository;

namespace PebCareHub.UniOfWork;

    public interface IUnitOfWork :IDisposable
    {
        IRoleRepository Roles { get; }
        ICustormerRepository Customer { get; }
        Task<bool> SaveChangesAsync();

}
