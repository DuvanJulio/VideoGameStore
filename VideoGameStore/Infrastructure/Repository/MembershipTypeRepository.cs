using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class MembershipTypeRepository : AsyncRepository<MembershipTypeEntity>, IMembershipTypeRepository
    {
        public MembershipTypeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
