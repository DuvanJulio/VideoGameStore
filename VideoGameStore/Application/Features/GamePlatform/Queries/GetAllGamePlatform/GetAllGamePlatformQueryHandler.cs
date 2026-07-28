using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.GamePlatform.Queries.GetAllGamePlatform
{
    public class GetAllGamePlatformQueryHandler : IRequestHandler<GetAllGamePlatformQuery, List<GamePlatformEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGamePlatformQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GamePlatformEntity>> Handle(GetAllGamePlatformQuery request, CancellationToken cancellationToken)
        {
            var gamePlatforms = await _unitOfWork.GamePlatformRepository.GetAllAsync();

            return gamePlatforms.ToList();
        }
    }
}
