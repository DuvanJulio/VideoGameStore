using MediatR;

namespace VideoGameStore.Application.Features.DeliveryType.Commands.InsertDeliveryType
{
    public class InsertDeliveryTypeCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
    }
}