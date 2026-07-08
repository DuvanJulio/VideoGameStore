using MediatR;

namespace VideoGameStore.Application.Features.Format.Commands.UpdateFormat
{
    public class UpdateFormatCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}