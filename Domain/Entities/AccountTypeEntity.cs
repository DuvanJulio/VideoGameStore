namespace VideoGameStore.Domain.Entities
{
    public class AccountTypeEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<ProductVariantEntity> ProductVariants { get; set; } = [];
    }
}
