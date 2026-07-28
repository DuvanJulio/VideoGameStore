using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class GamePlatformRepository : AsyncRepository<GamePlatformEntity>, IGamePlatformRepository
    {
        public GamePlatformRepository(DatabaseContext context) : base(context)
        {
        }
    }
}