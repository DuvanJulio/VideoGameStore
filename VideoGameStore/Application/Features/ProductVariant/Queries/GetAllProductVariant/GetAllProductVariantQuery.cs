using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.ProductVariant.Queries.GetAllProductVariant
{
    public class GetAllProductVariantQuery : IRequest<List<ProductVariantEntity>>
    {
    }
}
