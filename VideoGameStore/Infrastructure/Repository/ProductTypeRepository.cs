using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class ProductTypeRepository : AsyncRepository<ProductTypeEntity>, IProductTypeRepository
    {
        public ProductTypeRepository(DatabaseContext context) : base(context)
        {

        }
    }
}