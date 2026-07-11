using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.ProductType.Queries.GetProducTypeById
{
    public class GetProducTypeByIdQueryHandler : IRequestHandler<GetProducTypeByIdQuery, ProductTypeEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProducTypeByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductTypeEntity> Handle(GetProducTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var productTypeEntity = await _unitOfWork.ProductTypeRepository.GetByIdAsync(request.Id);

            if (productTypeEntity is null)
                throw new NotFoundException(nameof(ProductTypeEntity), request.Id);

            return productTypeEntity;
        }
    }
}