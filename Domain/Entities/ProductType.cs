namespace VideoGameStore.Domain.Entities
{
    public class ProductTypeEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<ProductEntity> Products { get; private set; } = [];        
    }
}