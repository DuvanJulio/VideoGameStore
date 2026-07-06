using MediatR;
using VideoGameStore.Application.Features.Game.Commands.SoftDeleteGame;
using VideoGameStore.Domain.Contracts.Repository;
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

        public async Task<bool> Handle(SoftDeleteGameCommand reques, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetByIdAsync(reques.Id, cancellationToken);

            if (game is null)
                throw new KeyNotFoundException("No se encontro el juego");

            game.IsActive = false;
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}