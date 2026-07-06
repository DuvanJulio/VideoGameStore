using MediatR;

namespace VideoGameStore.Application.Features.Game.Commands.SoftDeleteGame
{
    public class SoftDeleteGameCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}