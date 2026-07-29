using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class OrderDetailRepository : AsyncRepository<OrderDetailEntity>, IOrderDetailRepository
    {
        public OrderDetailRepository(DatabaseContext context) : base(context)
        {
        }
    }
}