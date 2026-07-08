using MediatR;

namespace VideoGameStore.Application.Features.Format.Commands.InsertFormat
{
    public class InsertFormatCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
    }
}