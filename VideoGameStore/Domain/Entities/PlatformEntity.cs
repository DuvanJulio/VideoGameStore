namespace VideoGameStore.Domain.Entities
{
    public class PlatformEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public long IdPlatformOwner { get; set; }

        public PlatformOwnerEntity? PlatformOwner { get; private set; }

        [JsonIgnore]
        public ICollection<GamePlatformEntity> GamePlatforms { get; private set; } = [];

        [JsonIgnore]
        public ICollection<MembershipEntity> Memberships { get; private set; } = [];
    }
}