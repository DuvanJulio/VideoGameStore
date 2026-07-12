namespace VideoGameStore.Domain.Entities
{
    public class OrderDetailEntity : BaseEntity
    {
        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public long IdProductVariant { get; set; }

        public long IdOrder { get; set; }

        public long IdMembership { get; set; }

        public ProductVariantEntity? ProductVariant { get; private set; }

        public OrderEntity? Order { get; private set; }

        public MembershipEntity? Membership { get; private set; }
    }
}