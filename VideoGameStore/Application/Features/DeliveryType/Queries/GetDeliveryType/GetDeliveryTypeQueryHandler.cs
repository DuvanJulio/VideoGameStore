using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.DeliveryType.Queries.GetDeliveryTypes
{
    public class GetDeliveryTypeQueryHandler : IRequestHandler<GetDeliveryTypeQuery, List<DeliveryTypeEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeliveryTypeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DeliveryTypeEntity>> Handle(GetDeliveryTypeQuery request, CancellationToken cancellationToken)
        {
            var acountTypes = await _unitOfWork.DeliveryTypeRepository.GetAllAsync();

            return acountTypes.ToList();
        }
    }
}
