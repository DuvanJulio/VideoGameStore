using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IMembershipRepository : IAsyncRepository<MembershipEntity>
    {}
}