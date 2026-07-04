using System.Reflection.Metadata.Ecma335;
using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Game.Commands.InsertGame
{
    public class InsertGameCommandHandler : IRequestHandler<InsertGameCommand, bool>
    {
        public readonly IUnitOfWork _uniOfWork;

        public InsertGameCommandHandler(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertGameCommand request, CancellationToken cancellationToken)
        {
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