using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Platform.Queries.GetAllPlatform
{
    public class GetAllPlatformQueryHandler : IRequestHandler<GetAllPlatformQuery, List<PlatformEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPlatformQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PlatformEntity>> Handle(GetAllPlatformQuery request, CancellationToken cancellationToken)
        {
            var platforms = await _unitOfWork.PlatformRepository.GetAllAsync();

            return platforms.ToList();
        }
    }
}
