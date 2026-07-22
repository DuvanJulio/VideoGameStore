using MediatR;

namespace VideoGameStore.Application.Features.Platform.Commands.DeletePlatform
{
    public class DeletePlatformCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}