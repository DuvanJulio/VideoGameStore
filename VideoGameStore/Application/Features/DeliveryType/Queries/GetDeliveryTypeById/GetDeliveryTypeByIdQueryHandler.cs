using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.DeliveryType.Queries.GetDeliveryTypesById
{
    public class GetDeliveryTypesByIdQueryHandler : IRequestHandler<GetDeliveryTypesByIdQuery, DeliveryTypeEntity>
    {
        private readonly IUnitOfWork _uniOfWork;

        public GetDeliveryTypesByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        public async Task<DeliveryTypeEntity> Handle(GetDeliveryTypesByIdQuery request, CancellationToken cancellationToken)
        {
            var DeliveryType = await _uniOfWork.DeliveryTypeRepository.GetByIdAsync(request.Id);

            if (DeliveryType is null)
                throw new NotFoundException();

            return DeliveryType;
        }
    }
}