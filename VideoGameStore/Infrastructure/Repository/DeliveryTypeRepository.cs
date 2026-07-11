using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class DeliveryTypeRepository : AsyncRepository<DeliveryTypeEntity>, IDeliveryTypeRepository
    {
        public DeliveryTypeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}