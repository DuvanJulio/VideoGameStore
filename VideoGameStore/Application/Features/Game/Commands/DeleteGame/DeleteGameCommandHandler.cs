using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Game.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetByIdAsync(request.Id, cancellationToken);

            if (game is null)
                throw new KeyNotFoundException($"No se encontro el juego con Id {request.Id}");

            await _unitOfWork.GameRepository.DeleteAsync(game, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}