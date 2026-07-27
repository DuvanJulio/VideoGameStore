using MediatR;

namespace VideoGameStore.Application.Features.MembershipType.Commands.DeleteMembershipType
{
    public class DeleteMembershipTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
