using VideoGameStore.Domain.Enums;

namespace VideoGameStore.Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        public long IdUser { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public decimal Total { get; set; }

        [JsonIgnore]
        public UserEntity? User { get; private set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; private set; } = [];
    }
}