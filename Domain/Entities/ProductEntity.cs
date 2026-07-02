namespace VideoGameStore.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public long IdProductType { get; set; }

        public long IdFormat { get; set; }

        public long IdGamePlatform { get; set; }
    }
}
