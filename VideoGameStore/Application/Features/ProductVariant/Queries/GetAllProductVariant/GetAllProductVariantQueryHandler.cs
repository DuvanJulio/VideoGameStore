using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.ProductVariant.Queries.GetAllProductVariant
{
    public class GetAllProductVariantQueryHandler : IRequestHandler<GetAllProductVariantQuery, List<ProductVariantEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductVariantQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductVariantEntity>> Handle(GetAllProductVariantQuery request, CancellationToken cancellationToken)
        {
            var productVariants = await _unitOfWork.ProductVariantRepository.GetAllAsync();

            return productVariants.ToList();
        }
    }
}
