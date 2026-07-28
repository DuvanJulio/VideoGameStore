using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.GamePlatform.Queries.GetGamePlatformById
{
    public class GetGamePlatformByIdQuery : IRequest<GamePlatformEntity>
    {
        public long Id { get; set; }
    }
}
