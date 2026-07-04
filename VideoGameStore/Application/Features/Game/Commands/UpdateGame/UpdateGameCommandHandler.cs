using MediatR;
using VideoGameStore.Domain.Contracts.Repository;

namespace VideoGameStore.Application.Features.Game.Commands.UpdateGame
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetByIdAsync<long>(request.Id);

            if (game is null)
                throw new KeyNotFoundException($"No se encontro el juego con Id {request.Id}");

            game.Name = request.Name;
            game.Description = request.Description;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}