using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.ProductType.Queries.GetAllProductType
{
    public class GetAllProductTypeQuery : IRequest<List<ProductTypeEntity>>
    {
        
    }
}