using MediatR;

namespace VideoGameStore.Application.Features.ProductVariant.Commands.InsertProductVariant
{
    public class InsertProductVariantCommand : IRequest<bool>
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public long IdProduct { get; set; }
        public long IdDeliveryType { get; set; }
    }
}
