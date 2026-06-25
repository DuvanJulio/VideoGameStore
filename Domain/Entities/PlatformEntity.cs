namespace VideoGameStore.Domain.Entities
{
    public class PlatformEntity : BaseEntity
    {
        public short IdPlatformOwner { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}