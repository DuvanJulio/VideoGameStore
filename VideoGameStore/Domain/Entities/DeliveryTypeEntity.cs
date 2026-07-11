namespace VideoGameStore.Domain.Entities
{
    public class DeliveryTypeEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<ProductVariantEntity> ProductVariants { get; private set; } = [];
    }
}
