using Microsoft.EntityFrameworkCore.Storage;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Infrastructure.Database;

namespace VideoGameStore.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DatabaseContext _context;

        public IDeliveryTypeRepository DeliveryTypeRepository { get; }

        public IGameRepository GameRepository { get; }


        public IProductTypeRepository ProductTypeRepository { get; }

        public IUserRepository UserRepository { get; }

        public IDbContextTransaction? _contextTransaction = null;

        public UnitOfWork(
            DatabaseContext context,
            IDeliveryTypeRepository deliveryTypeRepository,
            IGameRepository gameRepository,
            IProductTypeRepository productTypeRepository,
            IUserRepository userRepository)
        {
            _context = context;
            DeliveryTypeRepository = deliveryTypeRepository;
            GameRepository = gameRepository;
            ProductTypeRepository = productTypeRepository;
            UserRepository = userRepository;
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            var response = await _context.SaveChangesAsync(cancellationToken);
            return response;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _contextTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_contextTransaction is not null)
            {
                await _contextTransaction.CommitAsync(cancellationToken);
            }
        }

        public async Task RollBackAsync(CancellationToken cancellationToken = default)
        {
            if (_contextTransaction is not null)
            {
                await _contextTransaction.RollbackAsync(cancellationToken);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}