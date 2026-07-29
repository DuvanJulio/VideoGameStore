using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductEntity>
    {
        public long Id { get; set; }
    }
}
