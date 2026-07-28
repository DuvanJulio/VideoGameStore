using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.GamePlatform.Commands.InsertGamePlatform
{
    public class InsertGamePlatformCommandHandler : IRequestHandler<InsertGamePlatformCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public InsertGamePlatformCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertGamePlatformCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var platform = new GamePlatformEntity
            {
                IdGame = request.IdGame,
                IdPlatform = request.IdPlatform
            };

            await _unitOfWork.GamePlatformRepository.AddAsync(platform);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}
