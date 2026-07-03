namespace VideoGameStore.Domain.Entities
{
    public class FormatEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<ProductEntity> Products { get; private set; } = [];
    }
}