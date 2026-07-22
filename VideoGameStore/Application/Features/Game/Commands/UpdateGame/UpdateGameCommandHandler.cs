using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Application.Context;


namespace VideoGameStore.Application.Features.Game.Commands.UpdateGame
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;

        public UpdateGameCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
                throw new ForbiddenAccessException("");
                
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