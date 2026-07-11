using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.DeliveryType.Queries.GetDeliveryTypesById
{
    public class GetDeliveryTypesByIdQuery : IRequest<DeliveryTypeEntity>
    {
        public long Id { get; set; }
    }
}