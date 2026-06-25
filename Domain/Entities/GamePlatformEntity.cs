namespace VideoGameStore.Domain.Entities
{
    public class GamePlatformEntity : BaseEntity
    {
        public long IdGame { get; set; }

        public short IdPlatform { get; set; }
    }
}