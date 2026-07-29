using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class MembershipRepository : AsyncRepository<MembershipEntity>, IMembershipRepository
    {
        public MembershipRepository(DatabaseContext context) : base(context)
        {
        }
    }
}