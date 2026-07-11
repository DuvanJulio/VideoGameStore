using MediatR;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.DeleteDeliveryType
{
    public class DeleteDeliveryTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}