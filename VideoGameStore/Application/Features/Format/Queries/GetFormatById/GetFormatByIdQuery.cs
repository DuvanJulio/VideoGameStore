using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Format.Queries.GetFormatById
{
    public class GetFormatByIdQuery : IRequest<FormatEntity>
    {
        public long Id { get; set; }
    }
}