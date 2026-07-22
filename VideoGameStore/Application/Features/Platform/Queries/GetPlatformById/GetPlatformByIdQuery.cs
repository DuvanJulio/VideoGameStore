using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Platform.Queries.GetPlatformById
{
    public class GetPlatformByIdQuery : IRequest<PlatformEntity>
    {
        public long Id { get; set; }
    }
}
