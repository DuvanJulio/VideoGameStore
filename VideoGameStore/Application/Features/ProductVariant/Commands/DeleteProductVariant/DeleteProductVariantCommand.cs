using MediatR;

namespace VideoGameStore.Application.Features.ProductVariant.Commands.DeleteProductVariant
{
    public class DeleteProductVariantCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
