using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Platform.Queries.GetAllPlatform
{
    public class GetAllPlatformQuery : IRequest<List<PlatformEntity>>
    {
    }
}
