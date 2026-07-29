using MediatR;

namespace VideoGameStore.Application.Features.Order.Commands.InsertOrder
{
    public class InsertOrderCommand : IRequest<bool>
    {
        public long IdUser { get; set; }
        public decimal Total { get; set; }
    }
}
