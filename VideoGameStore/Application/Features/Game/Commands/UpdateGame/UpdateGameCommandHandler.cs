using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;


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
            var game = await _unitOfWork.GameRepository.GetByIdAsync(request.Id);

            if (game is null)
                throw new NotFoundException(nameof(GameEntity), request.Id);

            game.Name = request.Name;
            game.Description = request.Description;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}