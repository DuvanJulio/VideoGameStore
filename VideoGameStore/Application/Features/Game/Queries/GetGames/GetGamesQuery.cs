using MediatR;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Models.Response;

namespace VideoGameStore.Application.Features.Game.Queries.GetGames
{
    public class GetGamesQuery : IRequest<PagedResponse<GameEntity>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;

        public string? Name { get; set; }
    }
}