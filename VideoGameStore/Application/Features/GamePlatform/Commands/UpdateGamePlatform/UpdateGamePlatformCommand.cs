using MediatR;

namespace VideoGameStore.Application.Features.GamePlatform.Commands.UpdateGamePlatform
{
    public class UpdateGamePlatformCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public long IdGame { get; set; }
        public long IdPlatform { get; set; }
    }
}
