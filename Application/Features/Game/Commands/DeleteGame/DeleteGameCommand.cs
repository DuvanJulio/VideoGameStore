using MediatR;

namespace VideoGameStore.Application.Features.Game.Commands.DeleteGame
{
    public class DeleteGameCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}