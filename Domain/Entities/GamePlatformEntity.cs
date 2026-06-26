namespace VideoGameStore.Domain.Entities
{
    public class GamePlatformEntity : BaseEntity
    {
        public long IdGame { get; set; }

        public short IdPlatform { get; set; }
        
        public GameEntity? Game { get; set; }

        public PlatformEntity? Platform { get; set; }

        public ICollection<ProductEntity> Products { get; set; } = [];
    }
}