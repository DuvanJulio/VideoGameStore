using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Order.Queries.GetAllOrder
{
    public class GetAllOrderQuery : IRequest<List<OrderEntity>>
    {
    }
}
