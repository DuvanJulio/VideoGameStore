using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.DeliveryType.Queries.GetDeliveryTypes
{
    public class GetDeliveryTypeQuery : IRequest<List<DeliveryTypeEntity>>
    {
    }
}
