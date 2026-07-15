using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Domain.Contracts.Repository;

public interface IUserRepository : IAsyncRepository<UserEntity>
{
    Task<UserEntity?> GetByEmailAsync(string email);

    Task<bool> ExistsByEmailAsync(string email);
}
