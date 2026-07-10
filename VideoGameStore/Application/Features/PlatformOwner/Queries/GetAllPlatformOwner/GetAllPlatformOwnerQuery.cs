using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.PlatformOwner.Queries.GetAllPlatformOwner
{
    public class GetAllPlatformOwnerQuery : IRequest<List<PlatformOwnerEntity>>
    {
        
    }
}