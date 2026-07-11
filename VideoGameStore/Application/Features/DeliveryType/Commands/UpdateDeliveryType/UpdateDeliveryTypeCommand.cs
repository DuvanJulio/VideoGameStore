using MediatR;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.UpdateDeliveryType
{
    public class UpdateDeliveryTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}