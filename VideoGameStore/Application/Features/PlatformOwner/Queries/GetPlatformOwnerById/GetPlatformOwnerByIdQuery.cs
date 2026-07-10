using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.PlatformOwner.Queries.GetPlatformOwnerById
{
    public class GetPlatformOwnerByIdQuery : IRequest<PlatformOwnerEntity>
    {
        public long Id { get; set; }
    }
}