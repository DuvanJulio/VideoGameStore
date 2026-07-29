using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.ProductVariant.Queries.GetProductVariantById
{
    public class GetProductVariantByIdQuery : IRequest<ProductVariantEntity>
    {
        public long Id { get; set; }
    }
}
