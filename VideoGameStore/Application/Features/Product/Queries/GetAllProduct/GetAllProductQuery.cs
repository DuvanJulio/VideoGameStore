using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Product.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<List<ProductEntity>>
    {
    }
}
