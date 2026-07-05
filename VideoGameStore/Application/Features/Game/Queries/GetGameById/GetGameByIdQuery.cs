using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Game.Queries.GetGameById
{
    public class GetGameByIdQuery : IRequest<GameEntity>
    {
        public long Id { get; set; }
    }
}
