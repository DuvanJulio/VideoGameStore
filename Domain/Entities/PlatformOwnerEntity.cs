namespace VideoGameStore.Domain.Entities
{
    public class PlatformOwnerEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<PlatformEntity> Platforms { get; private set; } = [];

        public ICollection<GamePlatformEntity> GamePlatforms { get; private set; } = [];
    }
}