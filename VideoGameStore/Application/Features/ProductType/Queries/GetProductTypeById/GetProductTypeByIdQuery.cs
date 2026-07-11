using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.ProductType.Queries.GetProducTypeById
{
    public class GetProducTypeByIdQuery : IRequest<ProductTypeEntity>
    {
        public long Id { get; set; }
    }
}