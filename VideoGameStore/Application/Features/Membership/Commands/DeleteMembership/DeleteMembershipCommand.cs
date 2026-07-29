using MediatR;

namespace VideoGameStore.Application.Features.Membership.Commands.DeleteMembership
{
    public class DeleteMembershipCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
