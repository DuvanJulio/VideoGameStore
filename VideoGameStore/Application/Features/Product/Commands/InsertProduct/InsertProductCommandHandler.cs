using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Product.Commands.InsertProduct
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public InsertProductCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var product = new ProductEntity
            {
                Name = request.Name,
                Description = request.Description,
                IdGamePlatform = request.IdGamePlatform,
                IdProductType = request.IdProductType

            };

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}