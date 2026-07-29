using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.ProductVariant.Commands.InsertProductVariant
{
    public class InsertProductVariantCommandHandler : IRequestHandler<InsertProductVariantCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public InsertProductVariantCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertProductVariantCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var productVariant = new ProductVariantEntity
            {
                Price = request.Price,
                Stock = request.Stock,
                IdProduct = request.IdProduct,
                IdDeliveryType = request.IdDeliveryType
            };

            await _unitOfWork.ProductVariantRepository.AddAsync(productVariant);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}
