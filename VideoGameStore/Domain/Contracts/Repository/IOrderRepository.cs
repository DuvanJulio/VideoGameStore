using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IOrderRepository : IAsyncRepository<OrderEntity>
    {}
}