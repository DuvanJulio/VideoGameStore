using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.PlatformOwner.Commands.DeletePlatformOwner
{
    public class DeletePlatformOwnerCommandHandler : IRequestHandler<DeletePlatformOwnerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePlatformOwnerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePlatformOwnerCommand request, CancellationToken cancellationToken)
        {
            var platformOwner = await _unitOfWork.PlatformOwnerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (platformOwner is null)
                throw new NotFoundException(nameof(PlatformOwnerEntity));

            platformOwner.IsActive = false;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}