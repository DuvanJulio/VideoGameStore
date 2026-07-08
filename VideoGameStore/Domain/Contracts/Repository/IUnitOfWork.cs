namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccountTypeRepository AccountTypeRepository { get; }

        public IGameRepository GameRepository { get; }

        public IFormatRepository FormatRepository { get; }

        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);

        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitAsync(CancellationToken cancellationToken = default);

        Task RollBackAsync(CancellationToken cancellationToken = default);
    }
}