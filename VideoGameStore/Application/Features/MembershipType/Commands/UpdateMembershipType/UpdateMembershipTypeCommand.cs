using MediatR;

namespace VideoGameStore.Application.Features.MembershipType.Commands.UpdateMembershipType
{
    public class UpdateMembershipTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
