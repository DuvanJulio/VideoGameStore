using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.ProductType.Commands.DeleteProductType
{
    public class DeleteProductTypeCommandHandler : IRequestHandler<DeleteProductTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = await _unitOfWork.ProductTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (productType is null)
                throw new NotFoundException(nameof(ProductEntity));

            productType.IsActive = false;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}