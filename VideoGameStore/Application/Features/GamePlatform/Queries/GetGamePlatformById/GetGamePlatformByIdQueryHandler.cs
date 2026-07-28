using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.GamePlatform.Queries.GetGamePlatformById
{
    public class GetGamePlatformByIdQueryHandler : IRequestHandler<GetGamePlatformByIdQuery, GamePlatformEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGamePlatformByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GamePlatformEntity> Handle(GetGamePlatformByIdQuery request, CancellationToken cancellationToken)
        {
            var gamePlatform = await _unitOfWork.GamePlatformRepository.GetByIdAsync(request.Id);

            if (gamePlatform is null)
                throw new NotFoundException();

            return gamePlatform;
        }
    }
}
