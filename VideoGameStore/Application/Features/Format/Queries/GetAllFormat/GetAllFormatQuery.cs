using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Format.Queries.GetAllFormat
{
    public class GetAllFormatQuery : IRequest<List<FormatEntity>>
    {

    }
}