using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Membership.Queries.GetAllMembership
{
    public class GetAllMembershipQuery : IRequest<List<MembershipEntity>>
    {
    }
}
