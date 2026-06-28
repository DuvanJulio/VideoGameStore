using MediatR;

namespace VideoGameStore.Application.Features.Game.Commands.UpdateGame
{
    public class UpdateGameCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}