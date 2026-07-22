using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.InsertDeliveryType
{
    public class InsertDeliveryTypeCommandHandler : IRequestHandler<InsertDeliveryTypeCommand, bool>
    {
        public readonly IUnitOfWork _uniOfWork;

        private readonly ICurrentUser _currentUser;

        public InsertDeliveryTypeCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _uniOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var DeliveryType = new DeliveryTypeEntity
            {
                Name = request.Name
            };

            await _uniOfWork.DeliveryTypeRepository.AddAsync(DeliveryType);
            await _uniOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }

    
}