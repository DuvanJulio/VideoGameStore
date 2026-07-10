using MediatR;

namespace VideoGameStore.Application.Features.PlatformOwner.Commands.DeletePlatformOwner
{
    public class DeletePlatformOwnerCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}