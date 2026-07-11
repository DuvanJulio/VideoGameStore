using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.ProductType.Commands.UpdateProductType
{
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand, bool>
    {
        public readonly IUnitOfWork _unitOfWork;

        public UpdateProductTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

         public async Task<bool> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = await _unitOfWork.ProductTypeRepository.GetByIdAsync(request.Id);

            if (productType is null)
                throw new NotFoundException(nameof(ProductTypeEntity), request.Id);

            productType.Name = request.Name;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}