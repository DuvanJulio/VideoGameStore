using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.PlatformOwner.Queries.GetPlatformOwnerById
{
    public class GetPlatformOwnerByIdQueryHandler : IRequestHandler<GetPlatformOwnerByIdQuery, PlatformOwnerEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlatformOwnerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PlatformOwnerEntity> Handle(GetPlatformOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var platformOwner = await _unitOfWork.PlatformOwnerRepository.GetByIdAsync(request.Id);

            if (platformOwner is null)
                throw new NotFoundException(nameof(PlatformOwnerEntity), request.Id);

            return platformOwner;
        }
    }
}