namespace VideoGameStore.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public long IdProductType { get; set; }

        public long IdFormat { get; set; }

        public long IdGamePlatform { get; set; }

        public ProductTypeEntity? ProductType { get; set; }

        public FormatEntity? Format { get; set; }

        public GamePlatformEntity? GamePlatform { get; set; }

        public ICollection<ProductVariantEntity> ProductVariants { get; set; } = [];

        public ICollection<MembershipEntity> Memberships { get; set; } = [];
    }
}
