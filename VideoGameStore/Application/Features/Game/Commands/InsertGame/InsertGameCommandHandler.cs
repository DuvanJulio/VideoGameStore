using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Exception;

namespace VideoGameStore.Application.Features.Game.Commands.InsertGame
{
    public class InsertGameCommandHandler : IRequestHandler<InsertGameCommand, bool>
    {
        private readonly IUnitOfWork _uniOfWork;

        private readonly ICurrentUser _currentUser;


        public InsertGameCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _uniOfWork = unitOfWork;

            _currentUser = currentUser;
        }

        public async Task<bool> Handle(InsertGameCommand request, CancellationToken cancellationToken)
        {
            

            if (_currentUser.Role != "Admin") 
                throw new ForbiddenAccessException("");

            var game = new GameEntity
            {
                Name = request.Name,
                Description = request.Description
            };

            await _uniOfWork.GameRepository.AddAsync(game);
            await _uniOfWork.SaveChangeAsync(cancellationToken);
            
            return true;
        }
    }
}