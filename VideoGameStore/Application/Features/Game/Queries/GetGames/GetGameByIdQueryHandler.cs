using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Game.Queries.GetGameById
{
    public class GetGameByIdHandler : IRequestHandler<GetGameByIdQuery, GameEntity?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGameByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GameEntity?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GameRepository.GetByIdAsync<long>(request.Id);
        }
    }
}
