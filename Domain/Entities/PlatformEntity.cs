namespace VideoGameStore.Domain.Entities
{
    public class PlatformEntity : BaseEntity
    {
        public short IdPlatformOwner { get; set; }

        public string Name { get; set; } = string.Empty;

        public PlatformOwnerEntity? PlatformOwner { get; set; }

        public ICollection<GamePlatformEntity> GamePlatforms { get; set; } = [];

        public ICollection<MembershipEntity> Memberships { get; set; } = [];
    }
}