namespace VideoGameStore.Domain.Entities
{
    public class MembershipEntity : BaseEntity
    {
        public long IdPlatform { get; set; }

        public long IdMembershipType { get; set; }

        public long IdDeliveryType { get; set; }

        public DeliveryTypeEntity? DeliveryType { get; private set; }

        public PlatformEntity? Platform { get; private set; }

        public MembershipTypeEntity? MembershipType { get; private set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; private set; } = [];
    }
}