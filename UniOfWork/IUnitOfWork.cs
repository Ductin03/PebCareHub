
using PebCareHub.Repository;

namespace PebCareHub.UniOfWork;

    public interface IUnitOfWork :IDisposable
    {
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<bool> SaveChangesAsync();

}
