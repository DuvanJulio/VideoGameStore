using Microsoft.EntityFrameworkCore;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository;

public class RoleRepository : AsyncRepository<RoleEntity>, IRoleRepository
{
    public RoleRepository(DatabaseContext context) : base(context)
    {
    }


    public async Task<RoleEntity?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Role
            .FirstOrDefaultAsync(r => r.Name == name, cancellationToken);
    }
}