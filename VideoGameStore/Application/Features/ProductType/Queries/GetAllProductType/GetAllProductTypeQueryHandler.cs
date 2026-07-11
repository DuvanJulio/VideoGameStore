using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.ProductType.Queries.GetAllProductType
{
    public class GetAllProductTypeQueryHandler : IRequestHandler<GetAllProductTypeQuery, List<ProductTypeEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductTypeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductTypeEntity>> Handle(GetAllProductTypeQuery request, CancellationToken cancellationToken)
        {
            var productTypes = await _unitOfWork.ProductTypeRepository.GetAllAsync();

            return productTypes.ToList();
        }
    }
}