using MediatR;
using VideoGameStore.Domain.Contracts.Repository;

namespace VideoGameStore.Application.Features.Game.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IUnitOfWork _IUnitOfWork;

        public DeleteGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _IUnitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _IUnitOfWork.GameRepository.GetByIdAsync<long>(request.Id);

            if (game is null)
                throw new KeyNotFoundException($"No se encontro el juego con Id {request.Id}");

            game.IsActive = false;

            await _IUnitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}