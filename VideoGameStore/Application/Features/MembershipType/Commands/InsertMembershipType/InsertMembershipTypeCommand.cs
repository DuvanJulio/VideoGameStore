using MediatR;

namespace VideoGameStore.Application.Features.MembershipType.Commands.InsertMembershipType
{
    public class InsertMembershipTypeCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
    }
}
