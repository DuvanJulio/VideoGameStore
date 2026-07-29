using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.OrderDetail.Queries.GetAllOrderDetail
{
    public class GetAllOrderDetailQuery : IRequest<List<OrderDetailEntity>>
    {
    }
}
