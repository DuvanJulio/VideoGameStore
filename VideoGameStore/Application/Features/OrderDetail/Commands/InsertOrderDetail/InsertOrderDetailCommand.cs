using MediatR;

namespace VideoGameStore.Application.Features.OrderDetail.Commands.InsertOrderDetail
{
    public class InsertOrderDetailCommand : IRequest<bool>
    {
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public long IdProductVariant { get; set; }
        public long IdOrder { get; set; }
        public long IdMembership { get; set; }
    }
}
