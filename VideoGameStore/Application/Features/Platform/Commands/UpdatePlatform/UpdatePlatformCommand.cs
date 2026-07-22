using MediatR;

namespace VideoGameStore.Application.Features.Platform.Commands.UpdatePlatform
{
    public class UpdatePlatformCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
