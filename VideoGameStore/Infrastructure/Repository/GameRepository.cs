using System.Drawing;
using Microsoft.EntityFrameworkCore;
using VideoGameStore.Application.Features.Game.Queries.GetGames;
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

        public async Task<(IReadOnlyList<GameEntity> Items, int TotalCount)> GetPagedAsync(int page, int size, string? name = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<GameEntity>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(x => x.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(cancellationToken);
            return (items, totalCount);
        }

    }
}