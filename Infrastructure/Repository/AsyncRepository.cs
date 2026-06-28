using Microsoft.EntityFrameworkCore;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly DatabaseContext _context;

        public AsyncRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync<U>(U id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            var entityAdded = _context.Set<T>().Add(entity);
            return await Task.Run(() => entityAdded.Entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await Task.Run(() => entity);
        }
    }
}