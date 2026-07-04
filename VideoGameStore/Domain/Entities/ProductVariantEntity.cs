namespace VideoGameStore.Domain.Entities
{
    public class ProductVariantEntity : BaseEntity
    {
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public long IdProduct { get; set; }

        public long IdAccountType { get; set; }

        public AccountTypeEntity? AccountType { get; private set; }
        
        public ProductEntity? Products { get; private set; }
    }
}