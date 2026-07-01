namespace VideoGameStore.Domain.Entities
{
    public class ProductVariantEntity : BaseEntity
    {
        public long IdProduct { get; set; }

        public long IdAccountType { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public ProductEntity? Product { get; set; }

        public AccountTypeEntity? AccountType { get; set; }
    }
}