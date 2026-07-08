using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class PlatformOwnerRepository : AsyncRepository<PlatformOwnerEntity>, IPlatformOwnerRepository
    {
        public PlatformOwnerRepository(DatabaseContext context) : base(context)
        {}
    }
}