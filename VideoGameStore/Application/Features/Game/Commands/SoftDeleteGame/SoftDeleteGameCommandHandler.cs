using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Application.Context;

namespace VideoGameStore.Application.Features.Game.Commands.SoftDeleteGame
{
    public class SoftDeleteGameCommandHandler : IRequestHandler<SoftDeleteGameCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public SoftDeleteGameCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;

        }

        public async Task<bool> Handle(SoftDeleteGameCommand request, CancellationToken cancellationToken)
        {

            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");

            var game = await _unitOfWork.GameRepository.GetByIdAsync(request.Id, cancellationToken);

            if (game is null)
                throw new NotFoundException("");

            game.IsActive = false;
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}