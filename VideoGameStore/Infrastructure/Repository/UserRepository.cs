using Microsoft.EntityFrameworkCore;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository;

public class UserRepository : AsyncRepository<UserEntity>, IUserRepository
{

    public UserRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
        return await _context.User
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.User.AnyAsync(u => u.Email == email);
    }
}