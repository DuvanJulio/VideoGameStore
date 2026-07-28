using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.GamePlatform.Commands.UpdateGamePlatform
{
    public class UpdateGamePlatformCommandHandler : IRequestHandler<UpdateGamePlatformCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public UpdateGamePlatformCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateGamePlatformCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var gamePlatform = await _unitOfWork.GamePlatformRepository.GetByIdAsync(request.Id, cancellationToken);
            if (gamePlatform is null)
                throw new NotFoundException();

            gamePlatform.IdGame = request.IdGame;
            gamePlatform.IdPlatform = request.IdPlatform;
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return true;
        }
    }
}
