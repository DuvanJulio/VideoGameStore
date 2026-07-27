using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.MembershipType.Queries.GetAllMembershipType
{
    public class GetAllMembershipTypeQuery : IRequest<List<MembershipTypeEntity>>
    {
    }
}
