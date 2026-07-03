namespace VideoGameStore.Domain.Entities
{
    public class PlatformOwnerEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<PlatformEntity> Platforms { get; private set; } = [];

        [JsonIgnore]
        public ICollection<GamePlatformEntity> GamePlatforms { get; private set; } = [];
    }
}