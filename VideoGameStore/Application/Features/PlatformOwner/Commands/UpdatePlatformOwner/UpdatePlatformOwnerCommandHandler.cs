using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.PlatformOwner.Commands.UpdatePlatformOwner
{
    public class UpdatetPlatformOwnerCommandHandler : IRequestHandler<UpdatePlatformOwnerCommand, bool>
    {
        public readonly IUnitOfWork _unitOfWork;

        public UpdatetPlatformOwnerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

         public async Task<bool> Handle(UpdatePlatformOwnerCommand request, CancellationToken cancellationToken)
        {
            var platformOwner = await _unitOfWork.PlatformOwnerRepository.GetByIdAsync(request.Id);

            if (platformOwner is null)
                throw new NotFoundException(nameof(PlatformOwnerEntity), request.Id);

            platformOwner.Name = request.Name;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}