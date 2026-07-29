using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class ProductVariantRepository : AsyncRepository<ProductVariantEntity>, IProductVariantRepository
    {
        public ProductVariantRepository(DatabaseContext context) : base(context)
        {
        }
    }
}