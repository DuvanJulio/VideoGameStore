using MediatR;

namespace VideoGameStore.Application.Features.OrderDetail.Commands.DeleteOrderDetail
{
    public class DeleteOrderDetailCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
