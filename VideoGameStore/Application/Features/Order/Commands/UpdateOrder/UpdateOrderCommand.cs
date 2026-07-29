using MediatR;
using VideoGameStore.Domain.Enums;

namespace VideoGameStore.Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
    }
}
