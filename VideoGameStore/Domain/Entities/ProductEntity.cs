namespace VideoGameStore.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public long IdGamePlatform { get; set; }

        public long IdProductType { get; set; }

        public GamePlatformEntity? GamePlatform { get; private set; }

        public ProductTypeEntity? ProductType { get; private set; }

        [JsonIgnore]
        public ICollection<ProductVariantEntity> ProductVariants { get; private set; } = [];

        [JsonIgnore]
        public ICollection<MembershipEntity> Memberships { get; private set; } = [];
    }
}
