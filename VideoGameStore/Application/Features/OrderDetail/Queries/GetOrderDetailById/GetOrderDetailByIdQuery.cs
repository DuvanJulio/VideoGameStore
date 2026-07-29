using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.OrderDetail.Queries.GetOrderDetailById
{
    public class GetOrderDetailByIdQuery : IRequest<OrderDetailEntity>
    {
        public long Id { get; set; }
    }
}
