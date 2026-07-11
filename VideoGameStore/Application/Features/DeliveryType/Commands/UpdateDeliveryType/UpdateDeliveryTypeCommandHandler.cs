using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.UpdateDeliveryType
{
    public class UpdateDeliveryTypeCommandHandler : IRequestHandler<UpdateDeliveryTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeliveryTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            var DeliveryType = await _unitOfWork.DeliveryTypeRepository.GetByIdAsync(request.Id);

            if (DeliveryType is null)
                throw new NotFoundException(nameof(DeliveryTypeEntity), request);

            DeliveryType.Name = request.Name;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}