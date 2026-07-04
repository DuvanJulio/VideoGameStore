namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IAsyncRepository<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T?> GetByIdAsync<U>(U id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);
    }
}
