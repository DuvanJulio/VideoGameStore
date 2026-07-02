namespace VideoGameStore.Domain.Entities
{
    public class ProductVariantEntity : BaseEntity
    {
        public long IdProduct {  get; set; }

        public short IdAccountType { get; set; }

        public decimal Price { get; set; }

        public int Stock {  get; set; }
    }
}