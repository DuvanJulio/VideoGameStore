namespace VideoGameStore.Domain.Entities
{
    public class ProductVariantEntity : BaseEntity
    {
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public long IdProduct { get; set; }

        public long IdDeliveryType { get; set; }

        public DeliveryTypeEntity? DeliveryType { get; private set; }

        public ProductEntity? Products { get; private set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; private set; } = [];
    }
}