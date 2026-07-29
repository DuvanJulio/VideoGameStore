using MediatR;

namespace VideoGameStore.Application.Features.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
