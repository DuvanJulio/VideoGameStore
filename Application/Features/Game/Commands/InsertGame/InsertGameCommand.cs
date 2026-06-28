using MediatR;

namespace VideoGameStore.Application.Features.Game.Commands.InsertGame
{
    public class InsertGameCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
