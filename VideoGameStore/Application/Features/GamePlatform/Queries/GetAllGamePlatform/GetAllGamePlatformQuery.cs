using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.GamePlatform.Queries.GetAllGamePlatform
{
    public class GetAllGamePlatformQuery : IRequest<List<GamePlatformEntity>>
    {
    }
}
