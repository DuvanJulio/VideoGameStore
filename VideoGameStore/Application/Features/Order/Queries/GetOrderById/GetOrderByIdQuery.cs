using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderEntity>
    {
        public long Id { get; set; }
    }
}
