using MediatR;

namespace VideoGameStore.Application.Features.OrderDetail.Commands.UpdateOrderDetail
{
    public class UpdateOrderDetailCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public long IdProductVariant { get; set; }
        public long IdOrder { get; set; }
        public long IdMembership { get; set; }
    }
}
