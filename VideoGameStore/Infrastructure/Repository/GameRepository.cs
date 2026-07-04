using System.Drawing;
using Microsoft.EntityFrameworkCore;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class GameRepository : AsyncRepository<GameEntity>, IGameRepository
    {
        public GameRepository(DatabaseContext context) : base(context)
        {
        } 

        public async Task<(IReadOnlyList<GameEntity> Items, int TotalCount)> GetPagedAsync(int page, int size)
        {
            var query = _context.Set<GameEntity>();
            var totalCount = await query.CountAsync();
            var items = await query
                .OrderBy(x => x.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            return (items, totalCount);
        }
    }
}