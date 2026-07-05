namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);        
    }
}
