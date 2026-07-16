using System.Reflection.Metadata.Ecma335;
using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

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
            if (!_currentUser.IsAuthenticated)
                throw new UnauthorizedAccessException("Usuario no autenticado");

            if (_currentUser.Role != "Admin" || _currentUser.UserId != 1)
                throw new UnauthorizedAccessException("Solo el Admin puede insertar juegos");

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