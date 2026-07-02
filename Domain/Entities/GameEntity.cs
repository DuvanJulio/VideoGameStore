namespace VideoGameStore.Domain.Entities
{
    public class GameEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<GamePlatformEntity> GamePlatforms { get; private set; } = [];
    }
}