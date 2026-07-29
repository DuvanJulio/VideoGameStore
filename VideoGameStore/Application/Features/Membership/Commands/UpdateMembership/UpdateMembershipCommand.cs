using MediatR;

namespace VideoGameStore.Application.Features.Membership.Commands.UpdateMembership
{
    public class UpdateMembershipCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public long IdPlatform { get; set; }
        public long IdMembershipType { get; set; }
        public long IdDeliveryType { get; set; }
    }
}
