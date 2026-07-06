using MediatR;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;

namespace VideoGameStore.Application.Features.Game.Queries.GetGames
{
    public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, PagedResponse<GameEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGamesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<GameEntity>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            var (items, totalCount) = await _unitOfWork.GameRepository.GetPagedAsync(request.Page, request.Size, request.Name, cancellationToken);

            return new PagedResponse<GameEntity>
            {
                Items = items.ToList(),
                TotalCount = totalCount,
                Page = request.Page,
                Size = request.Size
            };
        }
    }
}