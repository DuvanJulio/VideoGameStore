using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.ProductVariant.Queries.GetProductVariantById
{
    public class GetProductVariantByIdQueryHandler : IRequestHandler<GetProductVariantByIdQuery, ProductVariantEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductVariantByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductVariantEntity> Handle(GetProductVariantByIdQuery request, CancellationToken cancellationToken)
        {
            var productVariant = await _unitOfWork.ProductVariantRepository.GetByIdAsync(request.Id);

            if (productVariant is null)
                throw new NotFoundException();

            return productVariant;
        }
    }
}
