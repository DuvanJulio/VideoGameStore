using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class PlatformRepository : AsyncRepository<PlatformEntity>, IPlatformRepository
    {
        public PlatformRepository(DatabaseContext context) : base(context)
        {
        }
    }
}