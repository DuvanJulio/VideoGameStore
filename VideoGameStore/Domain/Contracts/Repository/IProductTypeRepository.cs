using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IProductTypeRepository : IAsyncRepository<ProductTypeEntity>
    {}
}