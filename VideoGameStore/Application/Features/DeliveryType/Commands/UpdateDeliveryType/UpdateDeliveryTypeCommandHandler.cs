using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;
using System.Diagnostics.CodeAnalysis;
using VideoGameStore.Application.Context;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.UpdateDeliveryType
{
    public class UpdateDeliveryTypeCommandHandler : IRequestHandler<UpdateDeliveryTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public UpdateDeliveryTypeCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");
                
            var DeliveryType = await _unitOfWork.DeliveryTypeRepository.GetByIdAsync(request.Id);

            if (DeliveryType is null)
                throw new NotFoundException();

            DeliveryType.Name = request.Name;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}