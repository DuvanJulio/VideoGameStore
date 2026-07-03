namespace VideoGameStore.Domain.Entities
{
    public class GamePlatformEntity : BaseEntity
    {
        public long IdGame { get; set; }

        public long IdPlatform { get; set; }

        public GameEntity? Game { get; private set; }

        public PlatformEntity? Platform { get; private set; }

        [JsonIgnore]
        public ICollection<ProductEntity> Products { get; private set; } = [];
    }
}