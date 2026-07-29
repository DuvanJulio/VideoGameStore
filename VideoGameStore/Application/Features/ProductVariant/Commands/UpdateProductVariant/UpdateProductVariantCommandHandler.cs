using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.ProductVariant.Commands.UpdateProductVariant
{
    public class UpdateProductVariantCommandHandler : IRequestHandler<UpdateProductVariantCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public UpdateProductVariantCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateProductVariantCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var productVariant = await _unitOfWork.ProductVariantRepository.GetByIdAsync(request.Id, cancellationToken);
            if (productVariant is null)
                throw new NotFoundException();

            productVariant.Price = request.Price;
            productVariant.Stock = request.Stock;
            productVariant.IdProduct = request.IdProduct;
            productVariant.IdDeliveryType = request.IdDeliveryType;
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return true;
        }
    }
}
