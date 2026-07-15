using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IRoleRepository : IAsyncRepository<RoleEntity>
    {
        Task<RoleEntity?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}