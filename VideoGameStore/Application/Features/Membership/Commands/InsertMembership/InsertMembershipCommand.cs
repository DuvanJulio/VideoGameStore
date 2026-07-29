using MediatR;

namespace VideoGameStore.Application.Features.Membership.Commands.InsertMembership
{
    public class InsertMembershipCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public long IdPlatform { get; set; }
        public long IdMembershipType { get; set; }
        public long IdDeliveryType { get; set; }
    }
}