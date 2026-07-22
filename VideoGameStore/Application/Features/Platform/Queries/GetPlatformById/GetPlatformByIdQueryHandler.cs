using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Platform.Queries.GetPlatformById
{
    public class GetPlatformByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, PlatformEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlatformByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PlatformEntity> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            var platform = await _unitOfWork.PlatformRepository.GetByIdAsync(request.Id);

            if (platform is null)
                throw new NotFoundException();

            return platform;
        }
    }
}
