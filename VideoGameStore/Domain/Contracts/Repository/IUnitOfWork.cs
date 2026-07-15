namespace VideoGameStore.Domain.Contracts.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IDeliveryTypeRepository DeliveryTypeRepository { get; }

        public IGameRepository GameRepository { get; }

        public IProductTypeRepository ProductTypeRepository { get; }

        public IUserRepository UserRepository { get; }

        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);

        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitAsync(CancellationToken cancellationToken = default);

        Task RollBackAsync(CancellationToken cancellationToken = default);
    }
}