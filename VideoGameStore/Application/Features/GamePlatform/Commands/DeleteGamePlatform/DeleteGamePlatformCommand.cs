using MediatR;

namespace VideoGameStore.Application.Features.GamePlatform.Commands.DeleteGamePlatform
{
    public class DeleteGamePlatformCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
