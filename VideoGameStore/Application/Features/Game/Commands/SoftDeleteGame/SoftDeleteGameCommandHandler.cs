using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Game.Commands.SoftDeleteGame
{
    public class SoftDeleteGameCommandHandler : IRequestHandler<SoftDeleteGameCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SoftDeleteGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(SoftDeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetByIdAsync(request.Id, cancellationToken);

            if (game is null)
                throw new NotFoundException(nameof(GameEntity));

            game.IsActive = false;
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}