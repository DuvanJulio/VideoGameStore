using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.PlatformOwner.Queries.GetAllPlatformOwner
{
    public class GetAllPlatformOwnerQueryHandler : IRequestHandler<GetAllPlatformOwnerQuery, List<PlatformOwnerEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPlatformOwnerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PlatformOwnerEntity>> Handle(GetAllPlatformOwnerQuery request, CancellationToken cancellationToken)
        {
            var PlatformOwner = await _unitOfWork.PlatformOwnerRepository.GetAllAsync();

            return PlatformOwner.ToList();
        }
    }
}