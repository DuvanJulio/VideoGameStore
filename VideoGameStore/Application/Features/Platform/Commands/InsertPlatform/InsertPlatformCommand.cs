using MediatR;

namespace VideoGameStore.Application.Features.Platform.Commands.InsertPlatform
{
    public class InsertPlatformCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
    }
}