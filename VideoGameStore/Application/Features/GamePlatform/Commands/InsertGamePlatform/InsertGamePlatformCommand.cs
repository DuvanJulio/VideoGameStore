using MediatR;

namespace VideoGameStore.Application.Features.GamePlatform.Commands.InsertGamePlatform
{
    public class InsertGamePlatformCommand : IRequest<bool>
    {
        public long IdGame { get; set; }
        public long IdPlatform { get; set; }
    }
}