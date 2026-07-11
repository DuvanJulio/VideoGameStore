using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.DeleteDeliveryType
{
    public class DeleteDeliveryTypeCommandHandler : IRequestHandler<DeleteDeliveryTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeliveryTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            var DeliveryType = await _unitOfWork.DeliveryTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (DeliveryType is null)
                throw new NotFoundException(nameof(DeliveryTypeEntity));

            DeliveryType.IsActive = false;
            
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}