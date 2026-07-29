using MediatR;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Features.Membership.Queries.GetMembershipById
{
    public class GetMembershipByIdQuery : IRequest<MembershipEntity>
    {
        public long Id { get; set; }
    }
}
