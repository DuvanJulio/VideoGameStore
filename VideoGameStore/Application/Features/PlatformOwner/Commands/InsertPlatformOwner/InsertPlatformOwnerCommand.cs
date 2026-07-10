using MediatR;

namespace VideoGameStore.Application.Features.PlatformOwner.Commands.InsertPlatformOwner
{
    public class InsertPlatformOwnerCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
    }
}