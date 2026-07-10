using MediatR;

namespace VideoGameStore.Application.Features.PlatformOwner.Commands.UpdatePlatformOwner
{
    public class UpdatePlatformOwnerCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}