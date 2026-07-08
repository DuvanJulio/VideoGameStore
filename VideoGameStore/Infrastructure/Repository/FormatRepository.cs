using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class FormatRepository : AsyncRepository<FormatEntity>, IFormatRepository
    {
        public FormatRepository(DatabaseContext context) : base(context)
        {}
    }
}