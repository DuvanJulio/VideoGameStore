using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.InsertDeliveryType
{
    public class InsertDeliveryTypeCommandHandler : IRequestHandler<InsertDeliveryTypeCommand, bool>
    {
        public readonly IUnitOfWork _uniOfWork;

        public InsertDeliveryTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertDeliveryTypeCommand request, CancellationToken cancellationToken)
        {
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