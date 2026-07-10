using MediatR;

namespace VideoGameStore.Application.Features.Format.Commands.DeleteFormat
{
    public class DeleteFormatCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}