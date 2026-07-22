using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Platform.Commands.DeletePlatform
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public DeletePlatformCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var platform = await _unitOfWork.PlatformRepository.GetByIdAsync(request.Id, cancellationToken);

            if (platform is null)
                throw new NotFoundException("");

            platform.IsActive = false;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}