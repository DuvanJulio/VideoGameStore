using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IGameRepository : IAsyncRepository<GameEntity>
    {
        Task<(IReadOnlyList<GameEntity> Items, int TotalCount)> GetPagedAsync(int page, int size);
    }
}