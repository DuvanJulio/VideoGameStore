using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Application.Context;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.DeleteDeliveryType
{
    public class DeleteDeliveryTypeCommandHandler : IRequestHandler<DeleteDeliveryTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public DeleteDeliveryTypeCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeleteDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var DeliveryType = await _unitOfWork.DeliveryTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (DeliveryType is null)
                throw new NotFoundException("");

            DeliveryType.IsActive = false;
            
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}