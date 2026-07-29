using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class ProductRepository : AsyncRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {

        }
    }
}