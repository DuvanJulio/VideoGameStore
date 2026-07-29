using MediatR;

namespace VideoGameStore.Application.Features.ProductVariant.Commands.UpdateProductVariant
{
    public class UpdateProductVariantCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public long IdProduct { get; set; }
        public long IdDeliveryType { get; set; }
    }
}
